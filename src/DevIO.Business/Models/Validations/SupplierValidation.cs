using DevIO.Business.Models;
using DevIO.Business.Models.Validations.Documents;
using FluentValidation;

namespace DevIO.Business.Models.Validations;

public class SupplierValidation : AbstractValidator<Supplier>
{
    public SupplierValidation()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        When(s => s.SupplierType == SupplierType.Individual, () =>
        {
            RuleFor(s => s.Document.Length).Equal(CpfValidation.CpfLength)
                .WithMessage("O campo Documento precisar ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(s => CpfValidation.Validate(s.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        });

        When(s => s.SupplierType == SupplierType.Corporate, () =>
        {
            RuleFor(s => s.Document.Length).Equal(CnpjValidation.CnpjLength)
                .WithMessage("O campo Documento precisar ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            RuleFor(s => CnpjValidation.Validate(s.Document)).Equal(true)
              .WithMessage("O documento fornecido é inválido");
        });
    }
}
