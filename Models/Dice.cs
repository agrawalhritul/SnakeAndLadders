using System.Security.Cryptography;

namespace SnakeAndLadders.Models;

public class Dice
{
    public static int Minimum => 1;
    public static int Maximum => 6;

    public static int Roll(int count) => RandomNumberGenerator.GetInt32(count * Minimum, count * Maximum);
}
