using Akvelon.FizzBuzz;
using Xunit;

namespace Akvelon.FizzBuzz.Tests;

public class FizzBuzzDetectorTests
{
    private readonly FizzBuzzDetector _detector = new();

    [Fact]
    public void GetOverlappings_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _detector.GetOverlappings(null!));
    }

    [Fact]
    public void GetOverlappings_InputTooShort_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => _detector.GetOverlappings("Hello"));
    }

    [Fact]
    public void GetOverlappings_InputTooLong_ThrowsArgumentException()
    {
        string input = new string('a', 101);

        Assert.Throws<ArgumentException>(
            () => _detector.GetOverlappings(input));
    }

    [Fact]
    public void GetOverlappings_ReplacesThirdAndFifthWords()
    {
        string input = "Mary had a little lamb";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.Equal("Mary had Fizz little Buzz", result.OutputString);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetOverlappings_PreservesPunctuation()
    {
        string input = "One, two three four five.";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.Equal("One, two Fizz four Buzz.", result.OutputString);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetOverlappings_ReplacesFifteenthWordWithFizzBuzz()
    {
        string input =
            "w1 w2 w3 w4 w5 w6 w7 w8 w9 w10 w11 w12 w13 w14 w15";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.Contains("FizzBuzz", result.OutputString);
        Assert.Equal(7, result.Count);
    }

    [Fact]
    public void GetOverlappings_MatchesSpecificationExample()
    {
        string input =
            "Mary had a little lamb\n" +
            "Little lamb, little lamb\n" +
            "Mary had a little lamb\n" +
            "It's fleece was white as snow";

        string expected =
            "Mary had Fizz little Buzz\n" +
            "Fizz lamb, little Fizz\n" +
            "Buzz had Fizz little lamb\n" +
            "FizzBuzz fleece was Fizz as Buzz";

        FizzBuzzResult result = _detector.GetOverlappings(input);

        Assert.Equal(expected, result.OutputString);
        Assert.Equal(9, result.Count);
    }
}