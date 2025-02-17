partial class Program
{
    /// <summary>
    /// Sets the Operator of the game
    /// </summary>
    /// <returns>True if the Operator was set, false otherwise</returns>
    static bool ChooseOperator()
    {
        Console.Clear();
        Console.WriteLine("Choose Operator: ");

        foreach (Operators Operator in Enum.GetValues<Operators>())
        {
            Console.Write($"{(int)Operator}. {Operator}");
            Console.WriteLine();
        }

        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int Result)
            && Enum.GetValues<Operators>().Contains((Operators)Result))
        {
                SelectedOperator = (Operators)Result;
                Console.WriteLine($"You chose {SelectedOperator}");
                return true;
        }
        else
        {
            Console.WriteLine("Invalid choice");
            return false;
        }
    }
}
