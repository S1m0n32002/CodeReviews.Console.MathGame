partial class Program
{
    /// <summary>
    /// Sets the function of the game
    /// </summary>
    /// <returns>True if the function was set, false otherwise</returns>
    static bool ChooseFunction()
    {
        Console.Clear();
        Console.WriteLine("Choose function: ");

        foreach (Functions function in Enum.GetValues<Functions>())
        {
            Console.Write($"{(int)function}. {FunctionsStrings[function]}");

            if (function == Functions.PlayGame)
            {
                Console.Write($": {SelectedDifficulty}");
            }

            Console.WriteLine();
        }

        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int Result)
            && Enum.GetValues<Functions>().Contains((Functions)Result))
        {
                SelectedFunction = (Functions)Result;
                Console.WriteLine($"You chose {FunctionsStrings[SelectedFunction]}");
                return true;
        }
        else
        {
            Console.WriteLine("Invalid choice");
            return false;
        }
    }
}
