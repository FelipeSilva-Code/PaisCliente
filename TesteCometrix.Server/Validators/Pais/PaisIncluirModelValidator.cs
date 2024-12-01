using FluentValidation;

public class PaisIncluirModelValidator : AbstractValidator<PaisIncluirModel>
{
    public PaisIncluirModelValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(ExceptionTexts.PAIS_NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ExceptionTexts.PAIS_NOME_MINIMO_CARACTERES)
            .MaximumLength(50);
    }
}

