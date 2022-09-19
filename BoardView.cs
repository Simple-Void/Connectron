using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connectron
    //c# will be the death of me
{
    public partial class BoardView : Form
    {

        //variable setup
        //all variables made public so forms can reference them
        //also allows private subs like button presses to access
        //them as long as they're in the same class

        //setups for data imported from form one
        public int PlayerCount = 0;
        public int BoardSize = 0;
        public int WinLength = 0;
        public int BestOfRounds = 0;
        public bool[] SpecialRules = new bool[4];

        //player affected ints
        public int CountersPlaced = 0, PlayerTurn = 1, PlayerWon = 0,
                RoundsPlayed = 0;
        //program and checking ints
        public int temp = 0, BoardPrev = 0, DropX = 0,
            XPattern = 0, YPattern = 0, DropY = 0,
            TempX = 0, TempY = 0, GravX = 0, GravY = 0;
        //bool for bomb counters and valid condition
        public bool CounterIsBomb = false, Valid = false;
        //setup board, stored as an array to-be-setup as the
        //boardsize hasn't been recieved yet
        public int[,] Board;
        public bool[] BombUsed;
        public int[] PlayerWins;

        //setup the data sent from form 1
        public BoardView(int _PlayerCount, int _BoardSize,
            int _WinLength, int _BestOfRounds, bool[] _SpecialRules)
        {
            //variables transferred from form one as _<VARIABLE NAME>
            //this is good practice and avoids some conflicts
            //the global variables are then set to these transferred values
            PlayerCount = _PlayerCount;
            BoardSize = _BoardSize;
            WinLength = _WinLength;
            BestOfRounds = _BestOfRounds;
            SpecialRules = _SpecialRules;

            //setup board at runtime
            //technically bad practice but the alternatives are worse
            //what you gonna do it’s already programmed
            //update: about half the code is reliant on this I literally
            //can’t change this
            //spaghetti code
            //should’ve listened
            //literally about to add some gotos and lose the will to breathe
            //help brain no worky
            //update 2: it works now :)
            Board = new int[BoardSize, BoardSize];

            //set up the bombused to check
            BombUsed = new bool[PlayerCount + 1];
            //set up the playerwins var
            PlayerWins = new int[PlayerCount + 1];


            //initialise the form
            //sets up the WIMP components within the form with the values
            //given in the form designer, which is why there isn't a huge
            //section here
            InitializeComponent();

            //set slider size
            //this slider determines where to drop the counter
            //counts from one because that's how the size is counted
            //leads to a *lot* of '-1's down the line because the
            //datagridview counts from 0
            sliderDrop.Minimum = 1;
            sliderDrop.Maximum = BoardSize;
            //set the datagridview size
            DataBoard.ColumnCount = BoardSize;
            DataBoard.RowCount = BoardSize;
            //sets the grid square size
            //tiny grid it is :)
            //resizes squares dynamically
            for (int i = 0; i < BoardSize; i++)
            {
                //resizes the squares dynamically by dividing pixel count
                //by boardsize
                DataBoard.Columns[i].Width = (497 / BoardSize);
                DataBoard.Rows[i].Height = (497 / BoardSize);
            }
            //makes the selection box transparent, still needs to be user
            //updated
            //if something is placed there *while* selected, ugh
            DataBoard.RowsDefaultCellStyle.SelectionBackColor = System.
                Drawing.Color.Transparent;

            //sets all board values to 0
            //otherwise they retain a 'null' value
            //messes with some stuff down the line, so best to implement here
            for (int x = 0; x < BoardSize - 1; x++)
            { for (int y = 0; y < BoardSize - 1; y++)
                { Board[x, y] = 0;
                }
            }
        }
        //has to stay in, does nothing
        private void DataBoard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        //WORKS
        private void btnBomb_Click(object sender, EventArgs e)
        {
            //bomb only run if the code is appropriate the execute
            if (SpecialRules[2] == true)
            {
                //checks if the user has already used their bomb
                if (BombUsed[PlayerTurn] == true)
                {
                    //bomb already used, player cannot use bomb
                    MessageBox.Show("You have already used your bomb");
                } else
                {
                    //enables the counter being a bomb
                    CounterIsBomb = true;
                    //gives user feedback
                    MessageBox.Show("The next counter you drop will be a bomb");
                    //sets the bombused to true so they can't play it again
                    BombUsed[PlayerTurn] = true;
                }
            } else
            {
                //bomb not used and message given
                MessageBox.Show("The bomb rule is not enabled");
            }
        }
        //WORKS
        public void GravityColumn()
        {
            //this used to be old gravity that only handled dropping a counter,
            //but since the new gravity code loses the dropped coords of the counter
            //this can be resused to get the coordinates of the drop point
            //and thus use the bomb rule
            //apparently my own inability to code gravityb the way I wanted to worked
            //out in my favour!

            //loop up from the bottom to find the lowest empty cell
            for (int y = BoardSize - 1; y >= 0; y--)
            {
                //checks if the cell is empty
                if (Board[DropX, y] == 0)
                {
                    //swaps the empty for the full
                    Board[DropX, y] = Board[DropX, 0];
                    Board[DropX, 0] = 0;
                    RefreshPanel();
                    //saves the values so the bomb sub can reference the values
                    GravX = DropX;
                    GravY = y + 1;

                    //this was debugging stuff
                    //MessageBox.Show($"Bomb is at {DropX} {BombY}");
                    //DataBoard.Rows[y].Cells[DropX].Style.BackColor = Color.White;

                    //sets y too low so it exits
                    y = -1;
                }
            }

        }
        //WORKS
        public void Gravity()
        {
            //setup local variables
            //local coords for the grid to be able to back off and store a value
            int localx = 0, localy = 0;

            //goes through each column
            for (int x = 0; x <= BoardSize - 1; x++)
            {
                //checks the column several times to ensure fully dropepd
                for (int c = 1; c <= BoardSize; c++)
                {
                    //checks for lowest floating counter
                    for (int y = 0; y <= BoardSize - 1; y++)
                    {
                        //if the board value is 0
                        if (Board[x, y] == 0)
                        {
                            //go one prior and store those coords
                            localx = x;
                            localy = y - 1;
                            //sets y too high so loop exits
                            y = BoardSize;
                        }
                    }
                    //esnures there isn't an error by checking value
                    if (localy >= 0)
                    {
                        //loop up from the bottom to find the lowest empty cell
                        for (int y = BoardSize - 1; y >= 0; y--)
                        {
                            //checks if the cell is empty
                            if (Board[x, y] == 0)
                            {
                                Board[x, y] = Board[localx, localy];
                                Board[localx, localy] = 0;
                                RefreshPanel();
                                //sets y too low so it exits
                                y = -1;
                            }
                        }
                    }
                }
            }
        }
        //WORKS
        public void CPUPlayer()
        {
            //checks if the player count is fewer than two
            //if yes uses the AI
            if (PlayerCount == 1 && PlayerTurn != 1)
            {
                Valid = false;
                do
                {
                    //generates a random number
                    Random rnd = new Random();
                    //drops a counter in the cell selected randomly
                    DropX = rnd.Next(1, BoardSize - 1);
                    //puts it in the top row of the array / table

                    //if the column has the top space free drop the counter
                    if (Board[DropX, 0] == 0)
                    {
                        //sets the top board value as the counter, as this will always be free
                        Board[DropX, 0] = PlayerTurn;
                        //increments or resets playerturn
                        if (PlayerTurn < PlayerCount || PlayerTurn < 2)
                        {
                            //increments to next player
                            PlayerTurn++;
                        }
                        else
                        {
                            //resets to base
                            PlayerTurn = 1;
                        }
                        //AI picked a valid place and the loop can be exited
                        Valid = true;
                    }
                    else      //otherwise send a message
                    {
                        //MessageBox.Show("The AI picked a full column");
                        //the column is invalid and the AI must pick another
                        //so valid = false and the do while loop
                        //picks again
                        Valid = false;
                    }
                    //runs gravity but only for that column since it's only
                    //managing one counter at the moment
                    Gravity();

                    //checks to see if a player has won with any of the drops
                    if (SpecialRules[1] == true)
                    {
                        Solitaire();
                    }
                    CheckAllWinConditions();
                    RefreshPanel();
                } while (Valid != true);
            }
        }
        //TBD
        public void Solitaire()
        {
            //cycles through the whole grid
            for (int x = 0; x < BoardSize - 1; x++)
            {
                for (int y = 0; y < BoardSize - 1; y++)
                {
                    //section meant to cycle through the coordinates around
                    //the given area
                    SolitaireCoordsCheck(x, y);
                }
            }
        }
        private void SolitaireCoordsCheck(int _x, int _y)
        {
            //set up the ported variables
            int x = _x;
            int y = _y;
            //set up an array to store values for the checking further down
            int[] val = new int[11];
            int count = 1;

            //set all the values to something a square can't equal to show
            //a null value
            for (int m = 0; m <= 10; m++)
            {
                //set null value
                val[m] = 20;
            }

            //MessageBox.Show($"start coords of {x}, {y}");
            //loops a 3x3 grid
            for (int i = -1; i <= 1; i++)
            {
                for (int c = -1; c <= 1; c++)
                {
                    //checks for an error within the coordinate system
                    if (((x + i > -1) && (x + i <= BoardSize)) && ((y + c > - 1) 
                        && (y + c <= BoardSize)))
                    {
                        //checks the value at a given space within the board
                        //MessageBox.Show($"Checking the coordinates {(x + i)}, {(y + c)}");
                        val[count] = Board[(x + i), (y + c)];
                    }
                    //increments the count val every time so an inaccessible
                    //area is represented
                    
                    count++;
                }
            }

            //compare the values all around, if the values are equal then the
            //centre gets deleted
            if (val[1] == val[2] && val[1] == val[3] && val[1] == val[4] 
                && val[1] == val[6] && val[1] == val[7] && val[1] == val[8] && val[1] == val[9])
            {
                //if they are all equal, regardless of what is in the middle (this
                //makes it more fun because of friendly fire) the centre is deleted
                Board[x, y] = 0;
                Gravity();
            }
        }
        //WORKS
        public void Bomb()
        {
            //MessageBox.Show($"Bomb sub set for {BombX} {BombY}");
            //clear all the bomb affected areas
            //unfortunately due to an oversight programming the
            //gravity function, the bomb rule cannot access
            //where it has been dropped
            //so this function won't work unless I bring back old
            //single column gravity
            //single column grav is back and only runs for bomb rule,

            //simply deletes the area around the bomb
            for (int xcoord = -1; xcoord <= 1; xcoord++)
            {
                for (int ycoord = -1; ycoord <= 1; ycoord++)
                {
                    //checks the coords are valid so there isn't a crash
                    if (((GravY + ycoord) > -2 && (GravY + ycoord) < BoardSize) && 
                        ((GravX + xcoord) > -2 && (GravX + xcoord) < BoardSize))
                    {
                        //deletes the square
                        Board[GravX + xcoord, GravY + ycoord] = 0;
                        CountersPlaced--;
                    }
                }
            }
            Gravity();
            RefreshPanel();
        }
        //WORKS
        public void CheckAllWinConditions()
        {
            //can't have won if fewer than the minimum counters to
            //win have been placed, saves CPU time
            //reference the check sub with all appropriate
            //values for XPattern and YPattern to check all
            //the directions

            //if the board is full then it is a draw
            if (CountersPlaced >= BoardSize*BoardSize)
            {
                MessageBox.Show("Draw");
                //increment the roundsplayed
                RoundsPlayed++;
                if (RoundsPlayed >= BestOfRounds)
                {//all rounds finished, allow user to quit game
                    MessageBox.Show("You have played all your rounds");
                }
                else
                {
                    //reset the game and give a message
                    MessageBox.Show($"You just finished round {RoundsPlayed}, " +
                        $"you have {BestOfRounds - RoundsPlayed} rounds remaining");
                    Reset();
                }
                Reset();
            } else
            {
                //horizontal L --> R
                XPattern = 1;
                YPattern = 0;
                WinCheck();
                //vertical U --> D
                XPattern = 0;
                YPattern = -1;
                WinCheck();
                //diagonal L --> R, U --> D
                XPattern = 1;
                YPattern = -1;
                WinCheck();
                //diagonal R --> L, U --> D
                XPattern = -1;
                YPattern = -1;
                WinCheck();
            }
        }
        //WORKS
        public void WinCheck()
        {
            //setup variables
            //most are global but these don't really need to be
            //so I'll keep them local for better memory management
            int CurrentLength = 0;      //current length of the win check
            int BoardPrior = 0;         //prior value of the win check
            int TempX = 0, TempY = 0, CheckX = TempX,
                CheckY = TempY;         //checking integers for the runs


            //check win, return playerwon 0 - 10
            //cycles coords through all y values, resets y then
            //increments x

            //cycles all the x coordinates
            for (int x = 0; x < BoardSize; x++)
            {
                //cycles all the y coordinates
                for (int y = 0; y < BoardSize; y++)
                {
                    //checks to make sure the board spot isn't empty
                    if (Board[x, y] != 0)
                    {
                        //MessageBox.Show($"Board[{x}, {y}] != 0");
                        //updates the temporary values to share the default value
                        CheckX = x;
                        CheckY = y;
                        //starts a loop, this runs until either the check is over or a winner is found
                        BoardPrior = Board[x, y];
                        if (BoardPrior != 0)
                        {
                            //currentlength defaults to one when a non-blank space is found
                            CurrentLength = 1;
                            if (SpecialRules[3] == true)
                            {
                                if ((x == 0 || x == BoardSize - 1) && (y == 0 || y == BoardSize - 1))
                                {
                                    CurrentLength = CurrentLength + 3;
                                }
                            }
                            Valid = false;
                            do
                            {
                                //initialise the variables for the first run of the code
                                //base values
                                TempX = CheckX;
                                TempY = CheckY;
                                //advanced values to check ahead
                                CheckX = CheckX + XPattern;
                                CheckY = CheckY + YPattern;
                                //debug
                                //MessageBox.Show("Vars initialised for first attempt at loop");
                                //checks that the values aren't invalid for the process to run
                                //if it is valid it will run
                                if ((TempX <= BoardSize - 1 && TempX >= 0) && (TempY <= BoardSize - 1 && TempY >= 0)
                                    && (CheckX <= BoardSize - 1 && CheckX >= 0) && (CheckY <= BoardSize - 1 && CheckY >= 0))
                                {
                                    //sets boardprior to make code easier to read
                                    BoardPrior = Board[TempX, TempY];
                                    if (BoardPrior == Board[CheckX, CheckY])
                                    {
                                        //adds to currentlength if the two checked areas match
                                        CurrentLength++;
                                        if (SpecialRules[3] == true)
                                        {
                                            if ((CheckX == 0 || CheckX == BoardSize - 1) && (CheckY == 0 || CheckY == BoardSize - 1))
                                            {
                                                CurrentLength = CurrentLength + 3;
                                            }
                                        }
                                        //MessageBox.Show($"Values match to {CurrentLength}");
                                        //if the currentlength variable is long enough to count as a win
                                        if (CurrentLength >= WinLength)
                                        {
                                            //show the user that a player has won
                                            MessageBox.Show($"Player {BoardPrior} has won!!");
                                            Valid = true;
                                            //increment how many rounds have been played
                                            RoundsPlayed++;
                                            //if all played it will exit and finish
                                            if (RoundsPlayed >= BestOfRounds)
                                            {//all rounds finished, allow user to quit game
                                                MessageBox.Show("You have played all your rounds");
                                            }
                                            else
                                            {
                                                //reset the game and give a message
                                                MessageBox.Show($"You just finished round {RoundsPlayed}, " +
                                                    $"you have {BestOfRounds - RoundsPlayed} rounds remaining");
                                                PlayerWins[BoardPrior]++;
                                                Reset();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //otherwise the line is obviously broken so the win is impossible if not already reached
                                        Valid = true;
                                    }
                                } else      //otherwise the loop will exit and it will progress the base coordinates
                                {
                                    //valid is true to exit the loop
                                    Valid = true;
                                }

                            //end of the loop
                            } while (Valid != true);
                        }
                    }
                }
            }
        }
        //WORKS
        public void RefreshPanel()
        {
            //cycles through the whole array for the values
            //increments x coordinates
            for (int x = 0; x < BoardSize; x++)
            {
                //increments y coordinate
                for (int y = 0; y < BoardSize; y++)
                {
                    //select case condition for each of the player values
                    //cell colour changes depending on the player
                    switch (Board[x, y])
                    {
                        default:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.White;
                            break;
                        case 1:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Red;
                            break;
                        case 2:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                            break;
                        case 3:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Blue;
                            break;
                        case 4:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Green;
                            break;
                        case 5:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Purple;
                            break;
                        case 6:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Pink;
                            break;
                        case 7:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Orange;
                            break;
                        case 8:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Gray;
                            break;
                        case 9:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Brown;
                            break;
                        case 10:
                            DataBoard.Rows[y].Cells[x].Style.BackColor = Color.Black;
                            break;
                    }
                }
            }
        }
        public void Reset()
        {
            //run through all the vars that are edited and redefaults them
            //player affected ints
            CountersPlaced = 0;
            PlayerTurn = 1;
            PlayerWon = 0;
            //program and checking ints
            temp = 0;
            BoardPrev = 0;
            DropX = 0;
            XPattern = 0;
            YPattern = 0;
            DropY = 0;
            TempX = 0;
            TempY = 0;
            GravX = 0; 
            GravY = 0;
            //arrays
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    Board[x, y] = 0;
                }
            }
            for (int c = 0; c < PlayerCount + 1; c++)
            {
                BombUsed[c] = false;
            }
        }
        //WORKS
        private void btnDrop_Click(object sender, EventArgs e)
        {
            //takes value of the slider - 1
            //since the counter is from one and vars are from 0
            DropX = sliderDrop.Value - 1;
            //if the column has the top space free drop the counter
            if (Board[DropX, 0] == 0)
            {
                //sets the top board value as the counter, as this will
                //always be free
                Board[DropX, 0] = PlayerTurn;
                //GravityColumn();
                Gravity();
                //increments or resets playerturn
                if (PlayerTurn < PlayerCount || PlayerTurn < 2)
                {
                    //increments to next player
                    PlayerTurn++;
                } else
                {
                    //resets to base
                    PlayerTurn = 1;
                }
                //AI should only run if the player has actually placed
                //a counter
                //AI player
                CPUPlayer();
                CountersPlaced++;
            } else if (Board[DropX, 0] != 0 && SpecialRules[0] == true)
            {   //if overflow is in play and column is full
                //resets to invalidate the loop by default
                //becomes valid when the value it can be dropped in it found
                Valid = false;
                //loop to check until a valid spot is found
                for (int c = 0; c < BoardSize; c++)
                {
                    //loops through the whole top row
                    if (Board[c, 0] == 0)
                    {
                        //validates the loop to exit
                        Valid = true;
                        //changes DropX to c value
                        DropX = c;
                        //runs placement code as normal
                        //################################

                        //sets the top board value as the counter, as this will
                        //always be free
                        Board[DropX, 0] = PlayerTurn;
                        Gravity();
                        //increments or resets playerturn
                        if (PlayerTurn < PlayerCount || PlayerTurn < 2)
                        {
                            //increments to next player
                            PlayerTurn++;
                        }
                        else
                        {
                            //resets to base
                            PlayerTurn = 1;
                        }
                        //AI should only run if the player has actually placed
                        //a counter
                        //AI player
                        CPUPlayer();
                        CountersPlaced++;

                    }
                    if (Valid == true)
                    {
                        //makes c larger to exit the loop
                        c = BoardSize;
                    }
                }
            } else
            {
                MessageBox.Show("The column you are trying to " +
                    "place in is full, pick another column");
            }
            //if the bomb rule is in play
            if (SpecialRules[2] == true && CounterIsBomb == true)
            {
                //MessageBox.Show("bomb rule if statement and column grav");
                //run the sub to detonate the bomb
                GravityColumn();
                Bomb();
                CounterIsBomb = false;
            } else
            {
                //MessageBox.Show("proper grav no bomb");
                //runs gravity to drop counters
                Gravity();
            }

            //checks to see if a player has won with any of the drops
            if (SpecialRules[1] == true)
            {
                Solitaire();
                Gravity();
            }
            CheckAllWinConditions();
            RefreshPanel();
        }
    }
}
