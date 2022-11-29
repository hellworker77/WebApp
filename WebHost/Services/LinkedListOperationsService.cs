using WebHost.Abstractions;

namespace WebHost.Services;

public class LinkedListOperationsService : ILinkedListOperationsService
{
    public async Task<LinkedList<int>> GetSumOfTwoLinkedListsAsync(LinkedList<int> first, LinkedList<int> second)
    {
        var result = new LinkedList<int>();
        var previousDigitRemainder = 0;

        var nodeOfFirstList = first.First;
        var nodeOfSecondList = second.First;

        while (nodeOfFirstList != null || nodeOfSecondList != null)
        {
            var currentDigitValue = 0;
            var valueOfFirstNode = GetValueOfLinkedListNode(nodeOfFirstList);
            var valueOfSecondNode = GetValueOfLinkedListNode(nodeOfSecondList);

            currentDigitValue = GetSumOfOperands(currentDigitValue, valueOfFirstNode, valueOfSecondNode,
                previousDigitRemainder);

            previousDigitRemainder = currentDigitValue / 10;
            currentDigitValue %= 10;

            nodeOfFirstList = nodeOfFirstList?.Next;
            nodeOfSecondList = nodeOfSecondList?.Next;

            result.AddFirst(currentDigitValue);
        }

        if (previousDigitRemainder > 0) result.AddFirst(previousDigitRemainder);

        return await Task.FromResult(result);
    }

    public async Task<LinkedList<int>> GetLinkedListFromStringAsync(string origin)
    {
        var list = new LinkedList<int>();

        foreach (var symbol in origin)
        {
            var node = new LinkedListNode<int>(symbol - '0');
            list.AddFirst(node);
        }

        return await Task.FromResult(list);
    }

    private int GetSumOfOperands(int sum, params int[] values)
    {
        foreach (var value in values)
            if (value > 0)
                sum += value;

        return sum;
    }

    private int GetValueOfLinkedListNode(LinkedListNode<int>? node)
    {
        var value = -1;
        if (node != null) value = node.Value;

        return value;
    }
}