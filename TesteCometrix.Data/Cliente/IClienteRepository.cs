
public interface IClienteRepository
{
    public Task CadastrarClienteAsync(ClienteEntity clienteEntity);

    public Task EditarClienteAsync(ClienteEntity clienteEntity);

    public Task RemoverClienteAsync(ClienteEntity clienteEntity);

    public Task<List<ClienteEntity>> ConsultarClientesByNomeAsync(string nome);

    Task<ClienteEntity?> GetClienteById(int? idCliente);

    Task<bool> VerificarClienteComPais(int fkPais);
}
