public class CustomException : Exception
{
    public CustomException(string? mensagemUsuario) : base(mensagemUsuario)
    {
    }
}
