namespace WebHost.Abstractions;

public interface ILinkedListOperationsService
{
    public Task<LinkedList<int>> GetSumOfTwoLinkedListsAsync(LinkedList<int> first, LinkedList<int> second);
    public Task<LinkedList<int>> GetLinkedListFromStringAsync(string origin);

}