using System;
using System.Net;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace GUIGame
{
    public partial class GUIGame : Form
    {
        // VARIABLES

        private Difficult difficultIndex = Difficult.Normal;

        private int userScore = 0;
        private bool allowClick = false;

        private GameCard[] gameCards = { };
        private GameCard firstGuess;

        private readonly Random rnd = new Random();
        private readonly Stopwatch sw = new Stopwatch();
        private readonly Timer clickTimer = new Timer();

        // CONSTRUCTOR

        public GUIGame()
        {
            InitializeComponent();
            difficultOptions.SelectedIndex = (int)difficultIndex;
        }

        // PROPERTIES

        private static IEnumerable<Image> GameImages
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources.img1,
                    Properties.Resources.img2,
                    Properties.Resources.img3,
                    Properties.Resources.img4,
                    Properties.Resources.img5,
                    Properties.Resources.img6,
                    Properties.Resources.img7,
                    Properties.Resources.img8,
                    Properties.Resources.img9,
                    Properties.Resources.img10,
                    Properties.Resources.img11,
                    Properties.Resources.img12,
                    Properties.Resources.img13,
                    Properties.Resources.img14,
                    Properties.Resources.img15
                };
            }
        }

        // ENUMS

        private enum Difficult
        {
            Easy,   // = 0
            Normal, // = 1
            Hard    // = 2
        }

        private enum Images
        {
            Easy = 6,
            Normal = 10,
            Hard = 15
        }

        // GENERIC METHODS

        private IEnumerable<Image> GetRightImages()
        {
            IEnumerable<Image> currentImages = null;

            switch (difficultIndex)
            {
                case Difficult.Easy:
                    currentImages = GameImages.Take((int)Images.Easy);
                    break;

                case Difficult.Normal:
                    currentImages = GameImages.Take((int)Images.Normal);
                    break;

                case Difficult.Hard:
                    currentImages = GameImages.Take((int)Images.Hard);
                    break;
            }

            return currentImages;
        }

        private void ResetGameGrid()
        {
            int i = 0;
            PictureBox[] currentPictureBoxes = { };

            switch (difficultIndex)
            {
                case Difficult.Easy:
                    currentPictureBoxes = GameGridEasy.Controls.OfType<PictureBox>().ToArray();
                    break;

                case Difficult.Normal:
                    currentPictureBoxes = GameGridNormal.Controls.OfType<PictureBox>().ToArray();
                    break;

                case Difficult.Hard:
                    currentPictureBoxes = GameGridHard.Controls.OfType<PictureBox>().ToArray();
                    break;
            }

            gameCards = new GameCard[currentPictureBoxes.Length];

            foreach (var picBox in currentPictureBoxes)
            {
                gameCards[i] = new GameCard(picBox);
                gameCards[i].PicBox.Tag = null;
                gameCards[i].PicBox.Visible = true;
                i++;
            }

            HideImages();
            SetRandomImages();
        }

        private void HideImages()
        {
            foreach(var card in gameCards)
            {
                card.PicBox.Image = Properties.Resources.question;
            }
        }

        private void SetRandomImages()
        {
            foreach (var image in GetRightImages())
            {
                GetFreeSlot().PicBox.Tag = image;
                GetFreeSlot().PicBox.Tag = image;
            }
        }

        private GameCard GetFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, gameCards.Count());
            }
            while (gameCards[num].PicBox.Tag != null);

            return gameCards[num];
        }

        private void IncrementScore(int score)
        {
            userScore += score;
            scoreLabel.Text = userScore.ToString();
        }

        private void EndGame(string callingMethod)
        {
            allowClick = false;

            // Stop del timer di gioco
            sw.Stop();

            // Disabilitazione reset del gioco
            ResetButton.Enabled = false;

            // Inserimento nome utente ed invio dati al server
            if (callingMethod.Equals("ClickImage"))
            {
                TimeSpan ts = sw.Elapsed;
                string userName;

                do
                {
                    userName = Interaction.InputBox(
                        "\tYou Win! Congratulation!\n\n" +
                        "Your Time: " + string.Format("{0:00} : {1:00} : {2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds) + "\n" +
                        "Your Score: " + userScore.ToString() + "\n" +
                        "Insert your name or nickname: ", "YOU WIN!");
                    if (string.IsNullOrEmpty(userName))
                        MessageBox.Show("\tYou must insert a name or nickname", "ERROR!", MessageBoxButtons.OK);
                }
                while (string.IsNullOrEmpty(userName));

                // Inizio codice REST POST dati partita

                var url = "http://localhost:5000/save_user_game";

                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "POST";

                httpRequest.Accept = "application/json";
                httpRequest.ContentType = "application/json";

                var data = JsonConvert.SerializeObject(new
                {
                    name = userName.ToUpper(),
                    score = userScore,
                    time = string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds),
                    difficult = difficultIndex == Difficult.Easy ? "EASY" : difficultIndex == Difficult.Normal ? "NORMAL" : "HARD"
                });

                try
                {
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        streamWriter.Write(data);
                    }

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        Debug.WriteLine(result);
                    }

                    Debug.WriteLine(httpResponse.StatusCode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\t\t\tError:\n\n" + ex.Message, "WARNING!", MessageBoxButtons.OK);
                }

                // Fine codice REST POST dati partita
            }

            // Reset del timer di gioco
            sw.Reset();
            minutesLabel.Text = "00  :";
            secondsLabel.Text = "00  :";
            millisecondsLabel.Text = "00";

            // Reset Score
            userScore = 0;
            scoreLabel.Text = "0000";

            // Reset della griglia di gioco
            ResetGameGrid();

            // Riabilitazione opzioni di gioco
            StartButton.Enabled = true;
            difficultOptions.Enabled = true;
            RankButton.Enabled = true;
        }

        private Dictionary<string, List<Dictionary<string, string>>> GetAllRankedUsers()
        {
            // Inizio codice REST GET dati classifica utenti

            var url = "http://localhost:5000/get_all_rank";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.Accept = "application/json";
            httpRequest.ContentType = "application/json";

            var rankedUsers = new Dictionary<string, List<Dictionary<string, string>>>();
            try
            {
                var response = httpRequest.GetResponse();

                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd(); // ReadToEnd() ritorna una stringa da deserializzare
                    Debug.WriteLine(result);
                    rankedUsers = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, string>>>>(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\t\t\tError:\n\n" + ex.Message, "WARNING!", MessageBoxButtons.OK);
            }

            // Fine codice REST GET dati classifica utenti

            return rankedUsers;
        }

        // EVENTS METHODS

        private void SelectDifficult(object sender, EventArgs e)
        {
            difficultIndex = (Difficult)difficultOptions.SelectedIndex;
            switch (difficultIndex)
            {
                case Difficult.Easy:
                    GameGridEasy.Visible = true;
                    GameGridNormal.Visible = false;
                    GameGridHard.Visible = false;
                    break;

                case Difficult.Normal:
                    GameGridEasy.Visible = false;
                    GameGridNormal.Visible = true;
                    GameGridHard.Visible = false;
                    break;

                case Difficult.Hard:
                    GameGridEasy.Visible = false;
                    GameGridNormal.Visible = false;
                    GameGridHard.Visible = true;
                    break;
            }
        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!allowClick)
                return;

            var pic = (PictureBox)sender;
            var card = gameCards.Single(c => c.PicBox == pic);

            if (firstGuess == null)
            {
                firstGuess = card;
                firstGuess.IsFound = true;
                pic.Image = (Image)card.PicBox.Tag;
                return;
            }

            pic.Image = (Image)card.PicBox.Tag;

            if (card.IsFound)
                IncrementScore(-10);
            else
                card.IsFound = true;

            if (pic.Image == firstGuess.PicBox.Image && pic != firstGuess.PicBox)
            {
                IncrementScore(100);
                pic.Visible = firstGuess.PicBox.Visible = false;
                {
                    firstGuess.PicBox = pic;
                }
                HideImages();
            }
            else
            {
                IncrementScore(-20);
                allowClick = false;
                clickTimer.Start();
            }

            firstGuess = null;
            if (gameCards.Any(c => c.PicBox.Visible))
                return;

            // Qui si arriva solo in caso di vittoria
            EndGame("ClickImage");
        }

        private void StartGame(object sender, EventArgs e)
        {
            allowClick = true;
            ResetGameGrid();
            sw.Start();

            clickTimer.Interval = 700;
            clickTimer.Tick += CLICKTIMER_TICK;

            // Disabilitazione opzioni di gioco durante la partita
            StartButton.Enabled = false;
            difficultOptions.Enabled = false;
            RankButton.Enabled = false;

            // Abilitazione reset del gioco
            ResetButton.Enabled = true;
        }

        private void ResetGame(object sender, EventArgs e)
        {
            EndGame("ResetGame");
        }

        private void ViewRank(object sender, EventArgs e)
        {
            // disabilitazione momentanea dei pulsanti per evitare errori da parte dell'utente
            StartButton.Enabled = false;
            difficultOptions.Enabled = false;
            RankButton.Enabled = false;

            // recupero liste classifica utenti tramite API REST GET
            var allRankedUsers = GetAllRankedUsers();

            var easyRankedUsers = allRankedUsers["easy"];
            var normalRankedUsers = allRankedUsers["normal"];
            var hardRankedUsers = allRankedUsers["hard"];

            // setup form visualizzazione classifiche
            GUIRank guiRankForm = new GUIRank();
            guiRankForm.SetRankTable(easyRankedUsers, guiRankForm.EasyRankingTable);
            guiRankForm.SetRankTable(normalRankedUsers, guiRankForm.NormalRankingTable);
            guiRankForm.SetRankTable(hardRankedUsers, guiRankForm.HardRankingTable);

            // riabilitazioni pulsanti
            StartButton.Enabled = true;
            difficultOptions.Enabled = true;
            RankButton.Enabled = true;

            guiRankForm.ShowDialog();
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        private void GAMETIMER_TICK(object sender, EventArgs e)
        {
            TimeSpan ts = sw.Elapsed;

            minutesLabel.Text = string.Format("{0:00}  :", ts.Minutes);
            secondsLabel.Text = string.Format("{0:00}  :", ts.Seconds);
            millisecondsLabel.Text = string.Format("{0:000}", ts.Milliseconds);
        }
    }
}
