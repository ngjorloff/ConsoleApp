using System.Text.RegularExpressions;

namespace ConsoleApp;

public static class ArgumentExtensions
{
    public static object Add(this string first, string second)
    {
        if (string.IsNullOrEmpty(first))
        {
            throw new ArgumentException("First argument cannot be null or empty.", nameof(first));
        }

        if (string.IsNullOrEmpty(second))
        {
            throw new ArgumentException("Second argument cannot be null or empty.", nameof(second));
        }

        if (!ArgumentsAreNumeric(first, second))
        {
            return first + second;
        }

        if (HasDecimalValue(first) || HasDecimalValue(second))
        {
            return float.Parse(first) + float.Parse(second);
        }

        return int.Parse(first) + int.Parse(second);
    }

    private static bool ArgumentsAreNumeric(string first, string second)
    {
        return IsNumeric(first) && IsNumeric(second);
    }

    private static bool HasDecimalValue(string str) => new Regex(@"^\d+\.\d+$").IsMatch(str);

    private static bool IsNumeric(string str) => new Regex(@"^-?\d+(\.\d+)?$").IsMatch(str);
}