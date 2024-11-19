using Simulator;
namespace TestSimulator;
public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-5, 0, 10, 0)] // Mniejsze od minimalnego
    [InlineData(15, 0, 10, 10)] // Większe od maksymalnego
    public void Limiter_ReturnsClampedValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", 5, 10, '*', "abc**")]
    [InlineData("abcdefghijk", 5, 10, '*', "abcdefghij")] // Skrócone
    [InlineData("  abcd  ", 5, 10, '*', "abcd*")] // Trimowanie i dopasowanie
    public void Shortener_AdjustsStringCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}
