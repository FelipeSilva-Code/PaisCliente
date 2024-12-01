
public interface IClienteDomain
{
    public Task CadastrarClienteAsync(ClienteEntity clienteEntity);

    public Task EditarClienteAsync(ClienteEntity clienteEntity);

    public Task RemoverClienteAsync(int? idCliente);

    public Task<List<ClienteEntity>> ConsultarClientesByNomeAsync(string async);
}
