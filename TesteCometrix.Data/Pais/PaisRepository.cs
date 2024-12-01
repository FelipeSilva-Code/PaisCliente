using Microsoft.EntityFrameworkCore;

public class PaisRepository : IPaisRepository
{
    private readonly SqlDataContext _context;

    public PaisRepository (SqlDataContext context)
    {
        _context = context;
    }

    public async Task CadastrarPaisAsync(PaisEntity paisEntity)
    {
        _context.PaisEntity.Add(paisEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<PaisEntity>> ConsultarPaisesByNomeAsync(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return await _context.PaisEntity.AsNoTracking().ToListAsync();

        return await _context.PaisEntity
                                .Where(x => x.Nome.Contains(nome))
                                .AsNoTracking()
                                .ToListAsync();
    }

    public async Task EditarPaisAsync(PaisEntity paisEntity)
    {
        _context.PaisEntity.Update(paisEntity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverPaisAsync(PaisEntity paisEntity)
    {
        _context.PaisEntity.Remove(paisEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<PaisEntity?> GetPaisByIdAsync(int? idPais)
    {
        return await _context.PaisEntity
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == idPais.Value);
    }
}

