using Microsoft.EntityFrameworkCore;
using RiskScore.Infrastructure.Persistence;
using WalletPayment.Domain.Abstractions;

namespace WalletPayment.Infrastructure.Persistence.repositories;

public abstract class RepositoryBase<T> : IAsyncRepository<T> where T : class
{
    private ApplicationDbContext _context;

    protected ApplicationDbContext Context { get; }

    internal RepositoryBase(ApplicationDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
    }

    protected RepositoryBase(ApplicationDbContext context) => this._context = context;

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual void Add(T entity) => Context.Set<T>().Add(entity);
    public virtual void Update(T entity) => Context.Set<T>().Update(entity);
    public virtual void Delete(T entity) => Context.Set<T>().Remove(entity);
}
