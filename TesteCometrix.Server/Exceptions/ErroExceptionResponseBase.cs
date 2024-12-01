using System.Net;

namespace TesteCometrix.Server.Exceptions
{
    public class ErroExceptionResponseBase
    {

        //Para os erros do FluentValidation que retornam um array de mensagens de erro
        public ErroExceptionResponseBase(HttpStatusCode statusCode, IEnumerable<string> listaMensagem)
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<DetalhesErro>();
            CodigoStatus = (int)statusCode;
            DescricaoStatus = statusCode.ToString();
            AddErro(listaMensagem);
        }

        //Para os damais erros do sistema
        public ErroExceptionResponseBase(HttpStatusCode statusCode, string mensagem)
        {
            TraceId = Guid.NewGuid().ToString();
            Erros = new List<DetalhesErro>();
            CodigoStatus = (int)statusCode;
            DescricaoStatus = statusCode.ToString();
            AddErro(new[] { mensagem });
        }

        public string? TraceId { get; set; }

        public List<DetalhesErro> Erros { get; set; }

        public int CodigoStatus { get; set; }

        public string DescricaoStatus { get; set; }

        public class DetalhesErro
        {
            public DetalhesErro(string mensagem)
            {
                Mensagem = mensagem;
            }

            public string Mensagem { get; set; }
        }

        public void AddErro(IEnumerable<string> listaMensagemErro)
        {
            foreach (string mensagemErro in listaMensagemErro)
            {
                Erros.Add(new DetalhesErro(mensagemErro));
            }
        }
    }
}
