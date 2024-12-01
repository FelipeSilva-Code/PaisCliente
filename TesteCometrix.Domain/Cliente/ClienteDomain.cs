public class ClienteDomain : IClienteDomain
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IPaisRepository _paisRepository;

    public ClienteDomain(IClienteRepository clienteRepository, IPaisRepository paisRepository)
    {
        _clienteRepository = clienteRepository;
        _paisRepository = paisRepository;
    }

    public async Task CadastrarClienteAsync(ClienteEntity clienteEntity)
    {
        var paisCadastrado = await _paisRepository.GetPaisByIdAsync(clienteEntity.FkPais);

        if (paisCadastrado == null)
            throw new CustomException(ExceptionTexts.PAIS_NAO_ENCONTRADO);

        await _clienteRepository.CadastrarClienteAsync(clienteEntity);
    }

    public async Task<List<ClienteEntity>> ConsultarClientesByNomeAsync(string nome)
    {
        return await _clienteRepository.ConsultarClientesByNomeAsync(nome);
    }

    public async Task EditarClienteAsync(ClienteEntity clienteEntity)
    {
        var clienteEntityCadastrado = await _clienteRepository.GetClienteById(clienteEntity.Id);

        if (clienteEntityCadastrado == null)
            throw new CustomException(ExceptionTexts.CLIENTE_NAO_ENCONTRADO);

        var paisCadastrado = await _paisRepository.GetPaisByIdAsync(clienteEntity.FkPais);

        if (paisCadastrado == null)
            throw new CustomException(ExceptionTexts.PAIS_NAO_ENCONTRADO);

        clienteEntityCadastrado.Nome = clienteEntity.Nome;
        clienteEntityCadastrado.FkPais = clienteEntity.FkPais;

        await _clienteRepository.EditarClienteAsync(clienteEntityCadastrado);
    }

    public async Task RemoverClienteAsync(int? idCliente)
    {
        var clienteEntity = await _clienteRepository.GetClienteById(idCliente);

        if (clienteEntity == null)
            throw new CustomException(ExceptionTexts.CLIENTE_NAO_ENCONTRADO);

        await _clienteRepository.RemoverClienteAsync(clienteEntity);
    }
}
