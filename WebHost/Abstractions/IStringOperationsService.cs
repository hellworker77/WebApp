namespace WebHost.Abstractions;

public interface IStringOperationsService
{
    public Task<bool> IsPalindromeAsync(string source);
}