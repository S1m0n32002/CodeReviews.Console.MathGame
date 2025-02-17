using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Multiplication : IOperator
{
    static readonly Random rnd = new ();
    readonly int n1;
    readonly int n2;
    readonly int result;

    public Multiplication(Program.Difficulty Difficulty)
    {
        switch (Difficulty)
        {
            case Program.Difficulty.Easy:
                n1 = rnd.Next(0, 10);
                n2 = rnd.Next(0, 10);
                break;
            case Program.Difficulty.Medium:
                n1 = rnd.Next(0, 50);
                n2 = rnd.Next(0, 50);
                break;
            case Program.Difficulty.Hard:
                n1 = rnd.Next(0, 100);
                n2 = rnd.Next(0, 100);
                break;
        }

        result = n1 * n2;
    }

    /// <summary>
    /// Starts the game
    /// </summary>
    /// <returns>String with the result of the game</returns>
    public string? StartGame()
    {
        Console.WriteLine($"Multiplication the numbers {n1} and {n2}");

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

            return $"{n1} * {n2} = {Answer}\t(Correct result = {result})";
        }
        else
        {
            Console.WriteLine("Invalid input");
            return null;
        }
    }
}
