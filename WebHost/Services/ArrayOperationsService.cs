using WebHost.Abstractions;

namespace WebHost.Services;

public class ArrayOperationsService : IArrayOperationsService
{
    public async Task<int> GetModuleSumOfOddValuesAsync(int[] numbers)
    {
        var arrayOfOddValues = GetOddValues(numbers);
        var sum = 0;

        for (int i = 0; i < arrayOfOddValues.Length; i++)
        {
            if (i % 2 != 0)
            {
                sum ^= arrayOfOddValues[i];
            }
        }

        return await Task.FromResult(sum);
    }

    private int[] GetOddValues(int[] numbers)
    {
        var oddValues = new List<int>();

        foreach (var item in numbers)
        {
            if (item % 2 != 0)
            {
                oddValues.Add(item);
            }
        }

        return oddValues.ToArray();
    }
}