
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;
using SneddsyWorkspace.Apps.KratoApi.KratoApiDomain.Entities;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiPersistence.Repositories;

public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(KratoDbContext dbContext) : base(dbContext) {}
}