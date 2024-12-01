
public interface IPaisRepository
{
    public Task CadastrarPaisAsync(PaisEntity paisEntity);

    public Task EditarPaisAsync(PaisEntity paisEntity);

    public Task RemoverPaisAsync(PaisEntity paisEntity);

    public Task<List<PaisEntity>> ConsultarPaisesByNomeAsync(string nome);

    Task<PaisEntity?> GetPaisByIdAsync(int? idPais);
}

