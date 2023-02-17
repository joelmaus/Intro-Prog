
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        var delimeters = new List<char> { ',', '\n' };
        if (numbers == "")
        {
            return 0;
        }

        if (HasCustomDelimeter(numbers))
        {
            AddCustomDelimeter(numbers, delimeters);
            numbers = numbers.Substring(4);
        }

        var rawNumbers = numbers.Split(delimeters.ToArray())
            .Select(int.Parse);

        if (rawNumbers.Any(n => n < 0))
        {
            throw new NoNegativeNumbersException();
        }
        return rawNumbers
             .Sum(); // adds them up
    }

    private static void AddCustomDelimeter(string numbers, List<char> delimeters)
    {
        var delimeter = numbers.Substring(2, 1);
        delimeters.Add(char.Parse(delimeter));
    }

    private static bool HasCustomDelimeter(string numbers)
    {
        return numbers.StartsWith("//");
    }



}


public class NoNegativeNumbersException : ArgumentOutOfRangeException { }