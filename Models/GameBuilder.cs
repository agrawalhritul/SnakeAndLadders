namespace SnakeAndLadders.Models;

public class GameBuilder
{
    private readonly Game game = new();

    public GameBuilder AddPlayer(Player player)
    {
        game.Players.Enqueue(player);
        return this;
    }

    public GameBuilder AddPlayers(IEnumerable<Player> players)
    {
        foreach (var player in players)
        {
            game.Players.Enqueue(player);
        }
        return this;
    }

    public GameBuilder SetDiceCount(int diceCount)
    {
        game.DiceCount = diceCount;
        return this;
    }

    public Game Build() => game;
}