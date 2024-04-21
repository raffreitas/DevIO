using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Services;

public abstract class BaseService
{
    private readonly INotifier _notifier;

    protected BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var item in validationResult.Errors)
        {
            Notify(item.ErrorMessage);
        }
    }

    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
        where TV : AbstractValidator<TE>
        where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid) return true;

        Notify(validator);

        return false;
    }
}
