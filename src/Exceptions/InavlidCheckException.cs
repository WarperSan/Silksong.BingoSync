namespace Silksong.BingoSync.Exceptions;

/// <summary>
/// Exception thrown when a check doesn't support the received value
/// </summary>
/// <typeparam name="T">Type of the check</typeparam>
public class InvalidCheckException<T> : InvalidOperationException
{
	public InvalidCheckException(object data) : base($"No {typeof(T)} check is implemented for the value '{data}'.")
	{
	}
}