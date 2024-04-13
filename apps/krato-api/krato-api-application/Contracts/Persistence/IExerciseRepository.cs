using SneddsyWorkspace.Apps.KratoApi.KratoApiDomain.Entities;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;

public class IExerciseRepository : IAsyncRepository<Exercise> {
  public Task<Exercise> GetByIdAsync(Guid id)
  {
    throw new NotImplementedException();
  }
}