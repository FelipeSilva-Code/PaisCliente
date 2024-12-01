using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoCometrix.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteDomain _clienteDomain;

        public ClienteController(IClienteDomain clienteDomain) 
        { 
            _clienteDomain = clienteDomain;
        }

        [HttpPost]
        public async Task CadastrarCliente([FromBody] ClienteIncluirModel incluirModel)
        {

            ClienteEntity clienteEntity = new ClienteEntity()
            {
                Nome = incluirModel.Nome,
                FkPais = incluirModel.FkPais.Value
            };

            await _clienteDomain.CadastrarClienteAsync(clienteEntity);
        }

        [HttpPut]
        public async Task EditarCliente([FromBody] ClienteEditarModel alterarModel)
        {

            ClienteEntity clienteEntity = new ClienteEntity()
            {
                Id = alterarModel.Id,
                Nome = alterarModel.Nome,
                FkPais = alterarModel.FkPais.Value
            };

            await _clienteDomain.EditarClienteAsync(clienteEntity);
        }

        [HttpDelete("{id}")]
        public async Task RemoverCliente(int? id)
        {
            await _clienteDomain.RemoverClienteAsync(id.Value);
        }

        [HttpGet]
        public async Task<List<ClienteRetornoModel>> ConsultarClientesByNome([FromQuery] string? nome)
        {
            var clientes = await _clienteDomain.ConsultarClientesByNomeAsync(nome);
            return clientes.Select(x => new ClienteRetornoModel() 
                                { Id = x.Id, Nome = x.Nome, Pais = new PaisRetornoModel() 
                                { Id = x.Pais.Id, Nome = x.Pais.Nome } }).OrderBy(x => x.Nome).ToList();
        }
    }
}
