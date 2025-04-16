using System.Threading;
using System.Threading.Tasks;
using Store.Application;
using Store.Application.Interfaces;

namespace Store.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly StoreDbContext _context;

    public UnitOfWork(StoreDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}