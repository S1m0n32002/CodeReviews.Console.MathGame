using System.Diagnostics;

internal partial class Program
{
    /// <summary>
    /// Enum for functions
    /// </summary>
    enum Functions
    {
        PlayGame = 1,
        ChooseDifficulty,
        History,
        Exit
    }

    /// <summary>
    /// Dictionary to store the strings that are printed in the main menu
    /// </summary>
    static readonly Dictionary<Functions, string> FunctionsStrings = new()
    {
        { Functions.PlayGame, "Play Game" },
        { Functions.ChooseDifficulty, "Choose Difficulty" },
        { Functions.History, "History" },
        { Functions.Exit, "Exit :(" }
    };

    /// <summary>
    /// Enum for difficulty
    /// </summary>
    internal enum Difficulty
    {
        Easy = 1,
        Medium,
        Hard
    }

    /// <summary>
    /// Enum for difficulty
    /// </summary>
    enum Operators
    {
        Addition = 1,
        Subtraction,
        Multiplication,
        Division,
        Random
    }

    /// <summary>
    /// Stores the selected function
    /// </summary>
    static Functions SelectedFunction = Functions.PlayGame;
    
    /// <summary>
    /// Stores the selected difficulty
    /// </summary>
    static Difficulty SelectedDifficulty = Difficulty.Easy;

    static Operators SelectedOperator = Operators.Addition;

    static readonly List<string> History = [];

    /// <summary>
    /// Main entry point
    /// </summary>
    /// <param name="args">Command line arguments</param>
    private static void Main(string[] args)
    {
        if (args.Length != 0)
        {
            throw new ArgumentException("No arguments should be used");
        }

        while (true)
        {
            if (ChooseFunction() != true)
                continue; // Invalid choice restarts the loop

            switch (SelectedFunction)
            {
                case Functions.PlayGame:
                    PlayGame();
                    break;
                case Functions.ChooseDifficulty:
                    ChooseDifficulty();
                    break;
                case Functions.History:
                    PrintHistory();
                    break;
                case Functions.Exit:
                    return;
            }
        }
    }

    /// <summary>
    /// Used to randomize the operator
    /// </summary>
    static readonly Random rnd = new();

    /// <summary>
    /// Starts the game
    /// </summary>
    static void PlayGame()
    {
        Console.Clear();

        IOperator? Operator = null;

        if (!ChooseOperator())
            return;

        do
        { 
            switch (SelectedOperator)
            {
                case Operators.Addition:
                    Operator = new Addition(SelectedDifficulty);
                    break;
                case Operators.Subtraction:
                    Operator = new Subtraction(SelectedDifficulty);
                    break;
                case Operators.Multiplication:
                    Operator = new Multiplication(SelectedDifficulty);
                    break;
                case Operators.Division:
                    Operator = new Division(SelectedDifficulty);
                    break;
                case Operators.Random:
                    IEnumerable<int> values =
                        from Operators x in Enum.GetValues<Operators>()
                        where x != Operators.Random
                        select (int)x;

                    SelectedOperator = (Operators)rnd.Next(values.Min(), values.Max());
                    continue;
            }
        }
        while (Operator is null);

        Stopwatch watch = Stopwatch.StartNew();

        if (Operator is null)
            return;

        Console.Clear();
        var result = Operator.StartGame();
        
        watch.Stop();

        if (result is not null)
        {
            History.Add($"{result}\t{watch.ElapsedMilliseconds/1000:0.0} seconds");
        }

        Console.WriteLine($"Time taken: {watch.ElapsedMilliseconds/1000:0.0} seconds");
        Console.WriteLine($"Press any key to return to the main menu...");
        Console.ReadKey(true);
    }

    /// <summary>
    /// Prints the history of the games
    /// </summary>
    static void PrintHistory()
    {
        Console.Clear();
        if (History.Count > 0)
        {
            Console.WriteLine( "Test\t\tCorrect answer\t\tTime Taken");
            Console.WriteLine( string.Join("\n", History));
        }
        else
        {
            Console.WriteLine("No history");
        }
            Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey(true);
    }

}