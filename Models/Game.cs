namespace SnakeAndLadders.Models;

public class Game
{
    public Board Board => new();

    public int DiceCount { get; set; } = 1;

    public Queue<Player> Players { get; } = new Queue<Player>();
    public Queue<Player> Winners { get; } = new Queue<Player>();

    public int MakeMove(Player player)
    {
        var nextPosition = player.Piece.Position + player.RollDice(DiceCount);
        if (nextPosition > 100)
            throw new Exception($"{player.Name} could not make a move");

        var snakeAtNextPosition = Board.Snakes.SingleOrDefault(p => p.Head == nextPosition);
        if (snakeAtNextPosition != null)
        {
            player.Piece.Position = snakeAtNextPosition.Tail;
            Console.WriteLine($"{player.Name} got bit by a snake. Came down to {snakeAtNextPosition.Tail}");
            return player.Piece.Position;
        }
        var ladderAtNextPosition = Board.Ladders.SingleOrDefault(p => p.Bottom == nextPosition);
        if (ladderAtNextPosition != null)
        {
            player.Piece.Position = ladderAtNextPosition.Top;
            Console.WriteLine($"{player.Name} climbed up the ladder. Current position {ladderAtNextPosition.Top}");
            return player.Piece.Position;
        }
        player.Piece.Position = nextPosition;
        Console.WriteLine($"{player.Name} made a move. Current position {player.Piece.Position}");
        return nextPosition;
    }

    public void Play()
    {
        while (Players.Count > 1)
        {
            var currentPlayer = Players.Dequeue();
            try
            {
                var currentPosition = MakeMove(currentPlayer);
                if (currentPosition == 100)
                {
                    Winners.Enqueue(currentPlayer);
                    Console.WriteLine($"{currentPlayer.Name} has won the match");
                }
                else
                    Players.Enqueue(currentPlayer);
            }
            catch
            {
                Console.WriteLine($"{currentPlayer.Name} could not make a move.");
                Players.Enqueue(currentPlayer);
            }
        }
    }
}