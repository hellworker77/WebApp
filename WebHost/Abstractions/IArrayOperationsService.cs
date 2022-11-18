namespace WebHost.Abstractions;

public interface IArrayOperationsService
{
    public Task<int> GetModuleSumOfOddValuesAsync(int[] numbers);
}