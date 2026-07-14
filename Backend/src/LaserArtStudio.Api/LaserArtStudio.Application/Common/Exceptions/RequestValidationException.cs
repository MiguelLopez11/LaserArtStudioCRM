namespace LaserArtStudio.Application.Common.Exceptions;

public sealed class RequestValidationException : Exception
{
    public Dictionary<string, string[]> Errors { get; }

    public RequestValidationException(
        Dictionary<string, string[]> errors)
        : base("One or more validation errors occurred.")
    {
        Errors = errors;
    }
}