using static IOperator;
internal class Multiplication : IOperator
{
    public Multiplication(Program.Difficulty Difficulty)
    {
        InitValuesByDifficulty(Difficulty);
        
        Result = N1 * N2;
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    /// <returns>String with the result of the game</returns>
    public string? StartGame()
    {
        Console.WriteLine($"Multiplication the numbers {N1} and {N2}");

        if (CheckAnswer(out int Answer))
        {
            return $"{N1} * {N2} = {Answer}\t(Correct result = {Result})";
        }
        else
        {
            return null;
        }
    }
}
