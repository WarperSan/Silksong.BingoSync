namespace Silksong.BingoSync.Exceptions;

/// <summary>
/// Exception thrown when a check doesn't support the received value
/// </summary>
/// <typeparam name="T">Type of the check</typeparam>
public class InvalidCheckException<T> : InvalidOperationException
{
	private const string MESSAGE = "No {0} check is implemented for the value '{1}'.";

	public InvalidCheckException(T data)
		: base(string.Format(MESSAGE, typeof(T), data)) { }
}
