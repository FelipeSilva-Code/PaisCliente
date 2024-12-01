using FluentValidation;

public class ClienteIncluirModelValidator : AbstractValidator<ClienteIncluirModel>
{
    public ClienteIncluirModelValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(ExceptionTexts.CLIENTE_NOME_OBRIGATORIO)
            .MinimumLength(2).WithMessage(ExceptionTexts.CLIENTE_NOME_MINIMO_CARACTERES)
            .MaximumLength(50);

        RuleFor(x => x.FkPais)
            .NotEmpty().WithMessage(ExceptionTexts.CLIENTE_PAIS_OBRIGATORIO);
    }
}

