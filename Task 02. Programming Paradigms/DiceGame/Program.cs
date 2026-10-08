Console.WriteLine("....Dice Roll Game....");
Random rand = new Random();
bool tie = true;

Console.WriteLine("Rolling dice...");

while (tie)
{
    // First roll is the player's, second is the computer's
    int player = rand.Next(1, 7);
    int computer = rand.Next(1, 7);

    Console.WriteLine($"Your dice score: {player}");
    Console.WriteLine($"Computer's dice score: {computer}");

    if (player > computer)
    {
        Console.WriteLine("Player won!");
        tie = false;
    }
    else if (player < computer)
    {
        Console.WriteLine("Computer won!");
        tie = false;
    }
    else
    {
        Console.WriteLine("It's a tie, rolling again...");
        Console.WriteLine();
    }
}

