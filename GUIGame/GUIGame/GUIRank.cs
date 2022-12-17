using System.Collections.Generic;
using System.Windows.Forms;

namespace GUIGame
{
    public partial class GUIRank : Form
    {
        // CONSTRUCTORS

        public GUIRank()
        {
            InitializeComponent();
        }

        // PROPERTIES

        public DataGridView EasyRankingTable 
        { 
            get { return easyRankingTable; }
        }
        public DataGridView NormalRankingTable
        {
            get { return normalRankingTable; }
        }
        public DataGridView HardRankingTable
        {
            get { return hardRankingTable; }
        }

        // GENERIC METHODS

        public void SetRankTable(List<Dictionary<string, string>> rankedUsers, DataGridView rankTable)
        {
            int i = 0;

            foreach(var user in rankedUsers)
            {
                i++;

                var rank = i.ToString();
                var name = user["name"];
                var bestTime = user["best_time"].Substring(3, user["best_time"].Length - 6);
                var bestScore = user["best_score"];

                var row = new string[] { rank, name, bestTime, bestScore };
                rankTable.Rows.Add(row);
            }
        }
    }
}
