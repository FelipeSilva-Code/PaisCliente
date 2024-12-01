using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly SqlDataContext _context;

    public ClienteRepository(SqlDataContext appDbContext)
    {
        this._context = appDbContext;
    }
    
    public async Task CadastrarClienteAsync(ClienteEntity clienteEntity)
    {
        _context.ClienteEntity.Add(clienteEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ClienteEntity>> ConsultarClientesByNomeAsync(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            return await _context.ClienteEntity
                                        .Include(x => x.Pais)
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        return await _context.ClienteEntity
                                .Include(x => x.Pais)
                                .Where(x => x.Nome.Contains(nome))
                                .AsNoTracking()
                                .ToListAsync();
    }

    public async Task EditarClienteAsync(ClienteEntity clienteEntity)
    {
        _context.ClienteEntity.Update(clienteEntity);
        await _context.SaveChangesAsync();
    }


    public async Task RemoverClienteAsync(ClienteEntity clienteEntity)
    {
        _context.ClienteEntity.Remove(clienteEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<ClienteEntity?> GetClienteById(int? idCliente)
    {
        return await _context.ClienteEntity.FirstOrDefaultAsync(x => x.Id == idCliente);
    }

    public async Task<bool> VerificarClienteComPais(int fkPais)
    {
        return await _context.ClienteEntity.AnyAsync(x => x.FkPais == fkPais);
    }
}

