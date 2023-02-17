
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers == "")
        {
            return 0;
        }
        var (delimeters, n) = GetNormalizedDelimetersAndNumbers(numbers);
        

        var nums = n.Split(delimeters.ToArray())
             .Select(int.Parse);

        GuardAgainstNegatives(nums);
        
        return nums
            .Sum();
    }

    private void GuardAgainstNegatives(IEnumerable<int> numbers)
    {
        if (numbers.Any(n => n < 0))
        {
            throw new NoNegativeNumbersException();
        }
    }
    private (char[], string) GetNormalizedDelimetersAndNumbers(string numbers)
    {
        var delimeters = new List<char> { ',', '\n' };
        if (numbers.StartsWith("//"))
        {
            var delimeter = numbers.Substring(2, 1);
            delimeters.Add(char.Parse(delimeter));
            numbers = numbers.Substring(4);

        }
        return (delimeters.ToArray(), numbers);
    } 
}

public class NoNegativeNumbersException : ArgumentOutOfRangeException { }