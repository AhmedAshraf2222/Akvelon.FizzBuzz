using Akvelon.FizzBuzz;

namespace Akvelon_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var detector = new FizzBuzzDetector();

            string input =
                "Mary had a little lamb\n" +
                "Little lamb, little lamb\n" +
                "Mary had a little lamb\n" +
                "It's fleece was white as snow";

            FizzBuzzResult result = detector.GetOverlappings(input);

            Console.WriteLine("Output:");
            Console.WriteLine(result.OutputString);

            Console.WriteLine();
            Console.WriteLine($"Count: {result.Count}");
        }
    }
}