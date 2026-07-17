using System;
using System.Collections.Generic;
using System.Text;

namespace Akvelon.FizzBuzz;

/// <summary>
/// Represents the result of the FizzBuzz transformation.
/// </summary>
public class FizzBuzzResult
{
    public string OutputString { get; }

    public int Count { get; }

    public FizzBuzzResult(string outputString, int count)
    {
        OutputString = outputString;
        Count = count;
    }
}