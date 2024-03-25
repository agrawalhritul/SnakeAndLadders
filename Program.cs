using SnakeAndLadders.Models;
namespace SnakeAndLadders;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the number of Players");
        var playersCount = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter the name of the players in new line each");
        List<Player> players = new();
        for (int i = 0; i< playersCount; i++)
        {
            var player = new Player() { Name = Console.ReadLine()! , Piece = new()};
            players.Add(player);
        }

        Console.WriteLine("Enter the dice count");
        var diceCount = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter the snakes count");
        var snakesCount = int.Parse(Console.ReadLine()!);
        List<Snake> snakes = new();
        if (snakesCount > 0)
        {
            Console.WriteLine("Enter the snakes head and then bottom in each new line");
            for (int i = 0; i< snakesCount; i += 2)
        {
            var snake = new Snake(int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!));
            snakes.Add(snake);
        }
        }

        Console.WriteLine("Enter the ladders count");
        var laddersCount = int.Parse(Console.ReadLine()!);
        List<Ladder> ladders = new();
        if (laddersCount > 0)
        {
            Console.WriteLine("Enter the top and then bottom of the ladder in each new line");
            for (int i = 0; i<  laddersCount; i += 2)
            {
                var ladder = new Ladder(int.Parse(Console.ReadLine()!), int.Parse(Console.ReadLine()!));
                ladders.Add(ladder);
            }
        }

        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Game Starts");
        Console.WriteLine(Environment.NewLine);
        GameBuilder gameBuilder = new();
        var game = gameBuilder
            .SetDiceCount(diceCount)
            .AddPlayers(players)
            .Build();

        game.Board.Ladders.AddRange(ladders);
        game.Board.Snakes.AddRange(snakes);
        game.Play();

    }
}