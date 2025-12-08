namespace AOC25.Day1;

public class Dial
{
    public Dial() { }
    public Dial(int value) => Rotate(value);


    public int Value { get; private set; }


    public void Rotate(int amount) => Value = ((Value + amount) % 100 + 100) % 100;

    public void RotateRight(int amount) => Rotate(amount);

    public void RotateLeft(int amount) => Rotate(-amount);
}
