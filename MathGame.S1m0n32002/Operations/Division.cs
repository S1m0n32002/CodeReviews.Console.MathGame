using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Division : IOperator
{
    static readonly Random rnd = new ();
    readonly int dividend;
    readonly int divisor;
    readonly int result;

    public Division(Program.Difficulty Difficulty)
    {
        switch (Difficulty)
        {
            case Program.Difficulty.Easy:
                dividend = rnd.Next(0, 10);
                break;
            case Program.Difficulty.Medium:
                dividend = rnd.Next(0, 50);
                break;
            case Program.Difficulty.Hard:
                dividend = rnd.Next(0, 100);
                break;
        }

        do
        {
            divisor = rnd.Next(1, dividend);
        } while (dividend % divisor != 0); // && n1 == n2

        result = dividend / divisor;
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    /// <returns>String with the result of the game</returns>
    public string? StartGame()
    {
        Console.WriteLine($"Division the number {dividend} by {divisor}");

        if (int.TryParse(Console.ReadLine(), out int Answer))
        {
            if (Answer == result)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine($"Incorrect, the correct answer was: {result}");
            }

            return $"{dividend} / {divisor} = {Answer}\t(Correct result = {result})";
        }
        else
        {
            Console.WriteLine("Invalid input");
            return null;
        }
    }
}
