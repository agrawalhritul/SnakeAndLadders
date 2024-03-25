namespace SnakeAndLadders.Models;

public class Board
{
    public List<Snake> Snakes { get; set; } = new();
    public List<Ladder> Ladders { get; set; } = new();
}
