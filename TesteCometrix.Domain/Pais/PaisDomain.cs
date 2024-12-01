public class PaisDomain : IPaisDomain
{
    private readonly IPaisRepository _paisRepository;
    private readonly IClienteRepository _clienteRepository;

    public PaisDomain(IPaisRepository paisRepository, IClienteRepository clienteRepository)
    {
        _paisRepository = paisRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task CadastrarPaisAsync(PaisEntity paisEntity)
    {
        await _paisRepository.CadastrarPaisAsync(paisEntity);
    }

    public async Task<List<PaisEntity>> ConsultarPaisesByNomeAsync(string nome)
    {
        return await _paisRepository.ConsultarPaisesByNomeAsync(nome);
    }

    public async Task EditarPaisAsync(PaisEntity paisEntity)
    {
        var paisEntityCadastrado = await _paisRepository.GetPaisByIdAsync(paisEntity.Id);

        if (paisEntityCadastrado == null)
            throw new CustomException(ExceptionTexts.PAIS_NAO_ENCONTRADO);

        paisEntityCadastrado.Nome = paisEntity.Nome;

        await _paisRepository.EditarPaisAsync(paisEntityCadastrado);
    }

    public async Task RemoverPaisAsync(int? idPais)
    {
        if(idPais == null || idPais.Value <= 0)
            throw new CustomException(ExceptionTexts.PAIS_ID_OBRIGATORIO);

        var paisEntity = await _paisRepository.GetPaisByIdAsync(idPais);

        if (paisEntity == null)
            throw new CustomException(ExceptionTexts.PAIS_NAO_ENCONTRADO);

        if (await _clienteRepository.VerificarClienteComPais(idPais.Value))
            throw new CustomException(ExceptionTexts.PAIS_NAO_PERMITE_EXCLUSAO);

        await _paisRepository.RemoverPaisAsync(paisEntity);
    }
}
