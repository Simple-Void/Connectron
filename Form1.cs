namespace Connectron
{
    public partial class Form1 : Form
    {
        //set up variable inputs from current form
        //these should be class wide so any statics can reference them
        //single content variables
        int PlayerCount = 0;
        private int BoardSize = 0;
        int WinLength = 0;
        int BestOfRounds = 0;
        //the rules array stores all the rules, it's neater than
        //4 differently named variables
        bool[] SpecialRules = new bool[4];

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //stores values inputted from current form
            //slider intake values
            PlayerCount = sliderPlayerCount.Value;
            BoardSize = sliderBoardSize.Value;
            WinLength = sliderWinLength.Value;

            //check boxes, this checks if it's ticked and
            //then adds it as a rule
            //rules stored as a boolean array
            if (chkOverflow.Checked == true)
            { SpecialRules[0] = true; }
            if (chkSolitaire.Checked == true)
            { SpecialRules[1] = true; }
            if (chkBomb.Checked == true)
            { SpecialRules[2] = true; }
            if (chkCorners.Checked == true)
            { SpecialRules[3] = true; }

            //best of rounds
            //radiobuttons untick themselves if another is
            //ticked, so no error checking needed
            if (rd3rounds.Checked == true)
            { BestOfRounds = 3; }
            else
            { BestOfRounds = 5; }

            //debug for current variables setup
            //MessageBox.Show($"Player Count {sliderPlayerCount.Value},
            //Board Size {sliderBoardSize.Value}, Win Length {sliderWinLength.Value},
            //Overflow {chkOverflow.Checked}, Solitaire {chkSolitaire.Checked},
            //Bomb {chkBomb.Checked}, Corner {chkCorners.Checked}");

            //error check for if the win size is impossible
            if (WinLength > BoardSize)
            {
                //gives a message alerting them of the error and does not progress,
                //allowing them to reinput
                MessageBox.Show($"The win length ({WinLength}) must be smaller than" +
                    $" or equal to the board size ({BoardSize})");
            } else
            {
                //correct inputs
                //summon second form (game)
                //sends data to second form
                BoardView Board = new(PlayerCount, BoardSize, WinLength,
                    BestOfRounds, SpecialRules);
                //shows the main board
                Board.Show();
                //hides the input form (this one)
                //this.Hide();
            }
        }

        public Form1()
        { InitializeComponent(); }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void label1_Click_1(object sender, EventArgs e)
        { }
        private void trackBar2_Scroll(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        {
            //default to best of _ rounds being set to avoid errors
            rd3rounds.Checked = true;
            //set slider values to minimum for neatness :)
            sliderPlayerCount.Value = 1;
            sliderBoardSize.Value = 6;
            sliderWinLength.Value = 4;
        }
    }
}