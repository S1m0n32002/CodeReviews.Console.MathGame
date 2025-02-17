using static IOperator;
internal class Subtraction : IOperator
{
    public Subtraction(Program.Difficulty Difficulty)
    {
        InitValuesByDifficulty(Difficulty);

        Result = N1 - N2;
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    /// <returns>String with the result of the game</returns>
    public string? StartGame()
    {
        Console.WriteLine($"Subtract the numbers {N1} and {N2}");

        if (CheckAnswer(out int Answer))
        {
            return $"{N1} - {N2} = {Answer}\t(Correct result = {Result})";
        }
        else
        {
            return null;
        }
    }
}
