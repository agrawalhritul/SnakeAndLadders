namespace SnakeAndLadders.Models;

public class Player
{
    public string Name { get; init; }
    public Piece Piece { get; set; }
    public int RollDice(int diceCount) => Dice.Roll(diceCount);
}