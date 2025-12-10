using AOC25.Day1;
using Xunit;

namespace AOC25.Tests.Day1;

public class DialTests
{
    [Fact]
    public void ConstructorWithoutParametersCreatesDialAtZero()
    {
        var dial = new Dial();
        
        Assert.Equal(0, dial.Value);
    }

    [Fact]
    public void ConstructorWithValueSetsInitialPosition()
    {
        var dial = new Dial(50);
        
        Assert.Equal(50, dial.Value);
    }

    [Fact]
    public void RotatePositiveAmountIncreasesValue()
    {
        var dial = new Dial(10);
        
        dial.Rotate(5);
        
        Assert.Equal(15, dial.Value);
    }

    [Fact]
    public void RotateNegativeAmountDecreasesValue()
    {
        var dial = new Dial(20);
        
        dial.Rotate(-5);
        
        Assert.Equal(15, dial.Value);
    }

    [Fact]
    public void RotateWrapsAroundAt100()
    {
        var dial = new Dial(95);
        
        dial.Rotate(10);
        
        Assert.Equal(5, dial.Value);
    }

    [Fact]
    public void RotateWrapsAroundAtZeroWhenNegative()
    {
        var dial = new Dial(5);
        
        dial.Rotate(-10);
        
        Assert.Equal(95, dial.Value);
    }

    [Fact]
    public void RotateLargePositiveAmountWrapsCorrectly()
    {
        var dial = new Dial(50);
        
        dial.Rotate(200);
        
        Assert.Equal(50, dial.Value);
    }

    [Fact]
    public void RotateLargeNegativeAmountWrapsCorrectly()
    {
        var dial = new Dial(50);
        
        dial.Rotate(-200);
        
        Assert.Equal(50, dial.Value);
    }

    [Theory]
    [InlineData(0, 25, 25)]
    [InlineData(50, 50, 0)]
    [InlineData(99, 1, 0)]
    [InlineData(0, 100, 0)]
    [InlineData(75, 50, 25)]
    public void RotateWithVariousAmountsProducesCorrectValue(int start, int amount, int expected)
    {
        var dial = new Dial(start);
        
        dial.Rotate(amount);
        
        Assert.Equal(expected, dial.Value);
    }

    [Fact]
    public void RotateRightIncreasesValue()
    {
        var dial = new Dial(10);
        
        dial.RotateRight(5);
        
        Assert.Equal(15, dial.Value);
    }

    [Fact]
    public void RotateRightWrapsAt100()
    {
        var dial = new Dial(95);
        
        dial.RotateRight(10);
        
        Assert.Equal(5, dial.Value);
    }

    [Fact]
    public void RotateLeftDecreasesValue()
    {
        var dial = new Dial(20);
        
        dial.RotateLeft(5);
        
        Assert.Equal(15, dial.Value);
    }

    [Fact]
    public void RotateLeftWrapsAtZero()
    {
        var dial = new Dial(5);
        
        dial.RotateLeft(10);
        
        Assert.Equal(95, dial.Value);
    }

    [Fact]
    public void MultipleRotationsAccumulate()
    {
        var dial = new Dial(50);
        
        dial.Rotate(10);
        dial.Rotate(-5);
        dial.Rotate(20);
        
        Assert.Equal(75, dial.Value);
    }

    [Fact]
    public void RotateRightWithNegativeAmountDecreasesValue()
    {
        var dial = new Dial(20);
        
        dial.RotateRight(-5);
        
        Assert.Equal(15, dial.Value);
    }

    [Fact]
    public void RotateLeftWithNegativeAmountIncreasesValue()
    {
        var dial = new Dial(10);
        
        dial.RotateLeft(-5);
        
        Assert.Equal(15, dial.Value);
    }

    [Theory]
    [InlineData(-68)]
    [InlineData(-30)]
    [InlineData(48)]
    [InlineData(-5)]
    [InlineData(60)]
    [InlineData(-55)]
    [InlineData(-1)]
    [InlineData(-99)]
    [InlineData(14)]
    [InlineData(-82)]
    public void RotateHandlesInputFromProgram(int amount)
    {
        var dial = new Dial(50);
        
        dial.Rotate(amount);
        
        Assert.InRange(dial.Value, 0, 99);
    }

    [Fact]
    public void WhenSequenceFromProgramAppliedThenFinalPositionIsCorrect()
    {
        List<int> input = [-68, -30, 48, -5, 60, -55, -1, -99, 14, -82];
        var dial = new Dial(50);
        
        foreach (var change in input)
        {
            dial.Rotate(change);
        }
        
        Assert.Equal(32, dial.Value);
    }
}
