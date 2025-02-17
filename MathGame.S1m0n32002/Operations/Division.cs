using static IOperator;
internal class Division : IOperator
{
    readonly int dividend;
    readonly int divisor;
    readonly int result;

    public Division(Program.Difficulty Difficulty)
    {
        InitValuesByDifficulty(Difficulty);

        dividend = N1;

        do
        {
            divisor = rnd.Next(1, dividend);
        } while (dividend % divisor != 0);

        result = dividend / divisor;
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    /// <returns>String with the result of the game</returns>
    public string? StartGame()
    {
        Console.WriteLine($"Division the number {dividend} by {divisor}");

        if (CheckAnswer(out int Answer))
        {
            return $"{N1} / {N2} = {Answer}\t(Correct result = {Result})";
        }
        else
        {
            return null;
        }
    }
}
