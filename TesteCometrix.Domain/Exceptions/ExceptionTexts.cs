
public static class ExceptionTexts
{
    #region País
    public const string PAIS_ID_OBRIGATORIO = "É obrigatório informar o código do país";

    public const string PAIS_NAO_ENCONTRADO = "O cógido informado não pertence a nenhum país";

    public const string PAIS_NAO_PERMITE_EXCLUSAO = "Não é possível excluir o país, pois este está associado a um ou mais clientes";

    public const string PAIS_NOME_MINIMO_CARACTERES = "O nome do país deve conter ao menos 2 caracteres";

    public const string PAIS_NOME_OBRIGATORIO = "É obrigatório informar o nome do país";
    #endregion

    #region Cliente
    public const string CLIENTE_NAO_ENCONTRADO = "O cógido informado não pertence a nenhum cliente";

    public const string CLIENTE_NOME_OBRIGATORIO = "É obrigatório informar o nome do cliente";
    
    public const string CLIENTE_NOME_MINIMO_CARACTERES = "O nome do cliente deve conter ao menos 2 caracteres";

    public const string CLIENTE_PAIS_OBRIGATORIO = "É obrigatório informar o país do cliente";
    #endregion

}
