using FluentValidation;

public class PaisEditarModelValidator : AbstractValidator<PaisEditarModel>
{
    public PaisEditarModelValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(ExceptionTexts.PAIS_NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ExceptionTexts.PAIS_NOME_MINIMO_CARACTERES)
            .MaximumLength(50);
    }
}

