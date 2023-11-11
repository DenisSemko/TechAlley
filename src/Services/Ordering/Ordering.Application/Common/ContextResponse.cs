namespace Ordering.Application.Common;

public record ContextResponse(string Message, string Type, string StackTrace, IEnumerable<ValidationFailure>? Errors);