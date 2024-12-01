using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoCometrix.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : Controller
    {
        private readonly IPaisDomain _paisDomain;

        public PaisController(IPaisDomain paisDomain)
        {
            _paisDomain = paisDomain;
        }

        [HttpPost]
        public async Task CadastrarPais([FromBody] PaisIncluirModel incluirModel)
        {

            PaisEntity paisEntity = new PaisEntity()
            {
                Nome = incluirModel.Nome,
            };

            await _paisDomain.CadastrarPaisAsync(paisEntity);
        }

        [HttpPut]
        public async Task EditarPais([FromBody] PaisEditarModel alterarModel)
        {

            PaisEntity paisEntity = new PaisEntity()
            {
                Id = alterarModel.Id,
                Nome = alterarModel.Nome
            };

            await _paisDomain.EditarPaisAsync(paisEntity);
        }

        [HttpDelete("{id}")]
        public async Task RemoverPais(int? id)
        {
            await _paisDomain.RemoverPaisAsync(id);
        }

        [HttpGet]
        public async Task<List<PaisRetornoModel>> ConsultarPaisesByNomeAsync([FromQuery] string? nome)
        {
            var paises = await _paisDomain.ConsultarPaisesByNomeAsync(nome);
           
            return paises.Select(x => new PaisRetornoModel() { Id = x.Id, Nome = x.Nome}).OrderBy(x => x.Nome).ToList();
        }

    }
}
