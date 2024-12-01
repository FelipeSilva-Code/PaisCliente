public interface IPaisDomain
{
    public Task CadastrarPaisAsync(PaisEntity paisEntity);

    public Task EditarPaisAsync(PaisEntity paisEntity);

    public Task RemoverPaisAsync(int? idPais);

    public Task<List<PaisEntity>> ConsultarPaisesByNomeAsync(string nome);
}

