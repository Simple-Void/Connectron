namespace Connectron
{
    class Program
    {
        //set up all data structures for the program
        //these should be class wide so any statics can reference them

        //constants

        //single content variables
        int Temp = 0;

        int CounterPlaced = 0;
        int PlayerCount = 0;
        int PlayerTurn = 0;
        int PlayerWon = 0;
        int BoardSize = 0;
        int BoardPrev = 0;
        int WinLength = 0;
        int BestOfRounds = 0;
        int RoundsPlayed = 0;

        int DropX = 0;
        int TempX = 0;
        int TempY = 0;
        int CheckX = 0;
        int CheckY = 0;
        int XPattern = 0;
        int YPattern = 0;

        Boolean Bomb = false;
        Boolean Valid = false;

        //arrays
        List<String> PlayerNames = new List<string>();
        List<int> PlayerWins = new List<int>();
        int[,] Board = new int[100, 100];
        Boolean[] SpecialRules = new Boolean[4];

        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}