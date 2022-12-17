from flask import Flask, json, request
from sqlalchemy import exc, create_engine, MetaData, text, cast, func, Table, select, and_, INT
from sqlalchemy.dialects.mysql import TIME
from sqlalchemy_utils import database_exists, create_database

api = Flask(__name__)

# ----------------------------------  SETUP DATABASE  ------------------------------------------

DB_HOST = "localhost:3306"
DB_USER = "root"
DB_PASSWORD = "root"
DB_NAME = "pokemonmemoryrank"

DB_URL = "mysql://" + DB_USER + ":" + DB_PASSWORD + "@" + DB_HOST + "/" + DB_NAME + "?charset=utf8"

engine = create_engine(DB_URL, echo=True)
metadata = MetaData(bind=None)

if not database_exists(engine.url):
    create_database(engine.url)

    with engine.connect() as conn:  # code to create database from .sql file
        with open("./database_script.sql") as file:
            query = text(file.read())
            conn.execute(query)

users = Table('users', metadata, autoload=True, autoload_with=engine)
user_scores = Table('user_scores', metadata, autoload=True, autoload_with=engine)
easy_rank = Table('easy_rank', metadata, autoload=True, autoload_with=engine)
normal_rank = Table('normal_rank', metadata, autoload=True, autoload_with=engine)
hard_rank = Table('hard_rank', metadata, autoload=True, autoload_with=engine)

conn = engine.connect()


# -------------------------------------  API REST  ---------------------------------------------

@api.route('/save_user_game', methods=['POST'])
def save_user_game():
    if request.content_type == 'application/json':
        user_data = request.json

        s_user = users.select().where(users.c.name == user_data['name'])

        try:
            # .one() return a row (list) with the searched value or raise an NoResultFound exception
            user = conn.execute(s_user).one()
        except exc.NoResultFound:
            insert_user = users.insert().values(name=user_data['name'])
            conn.execute(insert_user)

            user = conn.execute(s_user).one()

        ins_score = user_scores.insert().values(
            id_user=cast(user[0], INT),  # user[0] means id_user column value ([1] is the name) of selected user
            time=cast(user_data['time'], TIME(fsp=3)),
            score=cast(user_data['score'], INT),
            difficult=user_data['difficult']
        )
        conn.execute(ins_score)

        # EASY RANKING
        rank_user(user, 'EASY', easy_rank)
        # NORMAL RANKING
        rank_user(user, 'NORMAL', normal_rank)
        # HARD RANKING
        rank_user(user, 'HARD', hard_rank)

        return json.dumps({"success": True}), 201
    else:
        return json.dumps({"success": False}), 500


@api.route('/get_all_rank', methods=['GET'])
def get_all_rank():
    results = {
        "easy": get_ranked_users(easy_rank),
        "normal": get_ranked_users(normal_rank),
        "hard": get_ranked_users(hard_rank)
    }
    return json.dumps(results, indent=4, sort_keys=True, default=str), 201


@api.route('/user_statistics', methods=['POST'])
def get_raw_user_data():
    if request.content_type == 'application/json':
        rcv_data = request.json

        s_user_id = users.select().with_only_columns(users.c.id_user).where(users.c.name == rcv_data['name'])
        user_id = conn.execute(s_user_id).scalar()

        if user_id is not None:
            results = {
                "EASY": get_user_scores_by_difficult(user_id, "EASY"),
                "NORMAL": get_user_scores_by_difficult(user_id, "NORMAL"),
                "HARD": get_user_scores_by_difficult(user_id, "HARD")
            }
            return json.dumps(results, indent=4, sort_keys=True, default=str), 201
        return json.dumps({"success": True}), 200
    else:
        return json.dumps({"success": False}), 500


# ---------------------------------  GENERIC METHODS  -----------------------------------------

def get_user_scores_by_difficult(user_id, difficult):
    s_user_data = user_scores.select().with_only_columns(
        user_scores.c.time,
        user_scores.c.score
    ).where(
        user_scores.c.id_user == user_id,
        user_scores.c.difficult == difficult
    )
    user_data = conn.execute(s_user_data).fetchall()

    keys = ("time", "score")
    results = get_list_of_dict(keys, user_data)

    return results


def get_list_of_dict(keys, list_of_tuples):
    list_of_dict = [dict(zip(keys, values)) for values in list_of_tuples]
    return list_of_dict


def rank_user(user, difficult, rank_table):
    s_best = select([func.min(user_scores.c.time), func.max(user_scores.c.score)]).where(
        and_(
            user_scores.c.difficult == difficult,
            user_scores.c.id_user == user[0]
        )
    )
    best = conn.execute(s_best).one()

    if any(elem is None for elem in best):
        return

    try:
        s_ranked_user = rank_table.select().where(rank_table.c.name == user[1])
        ranked_user = conn.execute(s_ranked_user).one()

        if best[0] < ranked_user[2] or best[1] > ranked_user[3]:
            up_ranked_user = rank_table.update().where(
                rank_table.c.name == ranked_user[1]
            ).values(
                best_time=best[0],
                best_score=best[1]
            )
            conn.execute(up_ranked_user)

    except exc.NoResultFound:
        ins_best = rank_table.insert().values(
            name=user[1],
            best_time=best[0],
            best_score=best[1]
        )
        conn.execute(ins_best)


def get_ranked_users(rank_table):
    s_ranked_users = rank_table.select().order_by(
        rank_table.c.best_time.asc(),
        rank_table.c.best_score.desc()
    )
    ranked_users = conn.execute(s_ranked_users).fetchall()
    results = []

    if ranked_users:  # --> if ranked_users list is not empty
        # results from sqlalchemy are returned as a list of tuples; this procedure converts it into a list of dicts
        keys = ("id", "name", "best_time", "best_score")
        results = get_list_of_dict(keys, ranked_users)
    return results


if __name__ == "__main__":
    api.run()
