namespace Bookify.Application.Abstraction.Behaviors;

public record ValidationError(string PropertyName, string ErrorMessage);