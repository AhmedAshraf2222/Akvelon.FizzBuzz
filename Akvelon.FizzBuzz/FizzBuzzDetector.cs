using System;
using System.Text;

namespace Akvelon.FizzBuzz;

/// <summary>
/// Replaces every third word with "Fizz", every fifth word with "Buzz",
/// and every fifteenth word with "FizzBuzz".
/// </summary>
public class FizzBuzzDetector
{
    private const int MinLength = 7;
    private const int MaxLength = 100;
    private const int FizzStep = 3;
    private const int BuzzStep = 5;

    /// <summary>
    /// Processes the input string and returns the transformed result.
    /// </summary>
    public FizzBuzzResult GetOverlappings(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (input.Length < MinLength || input.Length > MaxLength)
        {
            throw new ArgumentException(
                $"Input length must be between {MinLength} and {MaxLength}.");
        }

        var output = new StringBuilder(input.Length);

        int wordIndex = 0;
        int replacementCount = 0;
        int i = 0;

        while (i < input.Length)
        {
            if (IsWordCharacter(input[i]))
            {
                int start = i;

                while (i < input.Length && IsWordCharacter(input[i]))
                {
                    i++;
                }

                string word = input[start..i];

                wordIndex++;

                string? replacement = GetReplacement(wordIndex);

                if (replacement != null)
                {
                    output.Append(replacement);
                    replacementCount++;
                }
                else
                {
                    output.Append(word);
                }
            }
            else
            {
                output.Append(input[i]);
                i++;
            }
        }

        return new FizzBuzzResult(output.ToString(), replacementCount);
    }

    private static string? GetReplacement(int wordIndex)
    {
        bool fizz = wordIndex % FizzStep == 0;
        bool buzz = wordIndex % BuzzStep == 0;

        if (fizz && buzz)
        {
            return "FizzBuzz";
        }

        if (fizz)
        {
            return "Fizz";
        }

        if (buzz)
        {
            return "Buzz";
        }

        return null;
    }

    private static bool IsWordCharacter(char c)
    {
        return (c >= 'A' && c <= 'Z')
            || (c >= 'a' && c <= 'z')
            || (c >= '0' && c <= '9')
            || c == '\'';
    }
}