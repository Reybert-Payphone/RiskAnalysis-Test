namespace WalletPayment.Domain.Abstractions;

public interface IAsyncRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
