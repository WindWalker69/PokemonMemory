using System.Windows.Forms;

namespace GUIGame
{
    internal class GameCard
    {
        // CONSTRUCTOR

        public GameCard(PictureBox picBox)
        {
            PicBox = picBox;
            IsFound = false;
        }

        // PROPERTIES

        public PictureBox PicBox { get; set; }
        public bool IsFound { get; set; }
    }
}
