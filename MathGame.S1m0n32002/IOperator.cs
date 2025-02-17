using System.Dynamic;
using static Program;

/// <summary>
/// Interface for the Operator class.
/// </summary>
internal interface IOperator
{
    protected internal static int N1 { set; get; }
    protected internal static int N2 { set; get; }
    protected internal static int Result { set; get; }

    public abstract string? StartGame();

    protected internal static Random rnd = new();

    protected internal static void InitValuesByDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Program.Difficulty.Easy:
                N1 = rnd.Next(0, 10);
                N2 = rnd.Next(0, 10);
                break;
            case Program.Difficulty.Medium:
                N1 = rnd.Next(0, 50);
                N2 = rnd.Next(0, 50);
                break;
            case Program.Difficulty.Hard:
                N1 = rnd.Next(0, 100);
                N2 = rnd.Next(0, 100);
                break;
            default:
                N1 = 0;
                N2 = 0;
                break;
        }
    }

    /// <summary>
    /// Checks if the answer is correct
    /// </summary>
    /// <returns>True if the answer was evalued correctly, otherwise false</returns>
    protected internal static bool CheckAnswer(out int Answer)
    {
        if (int.TryParse(Console.ReadLine(), out Answer))
        {
            if (Answer == Result)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer was: {Result}");
            }
            return true;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return true;
        }
    }
}
