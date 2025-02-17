partial class Program
{
    /// <summary>
    /// Sets the difficulty of the game
    /// </summary>
    static void ChooseDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Choose difficulty: ");

        foreach (Difficulty difficulty in Enum.GetValues(typeof(Difficulty)))
        {
            Console.WriteLine($"{(int)difficulty}. {difficulty}");
        }

        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int Result))
        {
            SelectedDifficulty = (Difficulty)Result;
            Console.WriteLine($"You chose {SelectedDifficulty}");
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
