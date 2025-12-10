namespace AOC25.Day1;

public record struct DialPosition(int Value);

public static class DialPositionExtensions
{
    extension(DialPosition dial)
    {
        public DialPosition RotateDial(int amount)
        {
            dial.Value = (((dial.Value + amount) % 100) + 100) % 100;
            return dial;
        }
    }
}