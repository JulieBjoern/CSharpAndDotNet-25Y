namespace Opgave03;

public static class StringExtensions
{
    public static string ToLeetSpeak(this string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException(nameof(str));
        }

        //.Replace er en metode der erstatter et tegn med et andet. Man kunne også bruge StringBuilder som nævnt i tip. 
        return str
            .Replace("a", "4", StringComparison.OrdinalIgnoreCase)
            .Replace("e", "3", StringComparison.OrdinalIgnoreCase)
            .Replace("i", "1", StringComparison.OrdinalIgnoreCase)
            .Replace("o", "0", StringComparison.OrdinalIgnoreCase)
            .Replace("s", "5", StringComparison.OrdinalIgnoreCase)
            .Replace("t", "7", StringComparison.OrdinalIgnoreCase);
    } 
}