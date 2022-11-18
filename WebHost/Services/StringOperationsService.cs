using WebHost.Abstractions;

namespace WebHost.Services;

public class StringOperationsService : IStringOperationsService
{
    public async Task<bool> IsPalindromeAsync(string source)
    {
        var transformedString = TransformationString(source);

        var reversedString = ReverseString(transformedString);

        var result = transformedString.Equals(reversedString);

        return await Task.FromResult(result);
    }
    private string TransformationString(string input)
    {
        input = input.Replace(" ", "");

        return input.ToLower();
    }
    private string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}