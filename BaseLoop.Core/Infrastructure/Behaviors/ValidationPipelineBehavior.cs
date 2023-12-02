using BaseLoop.Core.ErrorHandling;
using BaseLoop.Core.Infrastructure.Commands;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BaseLoop.Core.Infrastructure.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where
    TRequest : ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => new Error
            {
                Title = x.PropertyName,
                Message = x.ErrorMessage
            }).Distinct().ToArray();

        if (errors.Any()) throw new ValidationException(CreateValidationResult(errors));
        return await next();
    }

    private static IEnumerable<ValidationFailure> CreateValidationResult(Error[] errors)
    {
        var validationResult = new List<ValidationFailure>();

        foreach (var error in errors) validationResult.Add(new ValidationFailure(error.Title, error.Message));

        return validationResult;
    }
}