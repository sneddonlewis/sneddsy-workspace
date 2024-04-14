namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
}
