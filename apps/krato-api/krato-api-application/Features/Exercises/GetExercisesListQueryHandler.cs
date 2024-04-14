
using AutoMapper;
using MediatR;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;
using SneddsyWorkspace.Apps.KratoApi.KratoApiDomain.Entities;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Features.Exercises;

public class GetExercisesListQueryHandler : IRequestHandler<GetExercisesListQuery, List<ExerciseListVm>>
{
    private readonly IExerciseRepository _exerciseRepo;
    private readonly IMapper _mapper;

    public GetExercisesListQueryHandler(
        IMapper mapper,
        IExerciseRepository exerciseRepository)
    {
        _mapper = mapper;
        _exerciseRepo = exerciseRepository;
    }

    public async Task<List<ExerciseListVm>> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
    {
        // var allExercises = await _exerciseRepo.ListAllAsync();
        // TODO swap this for line above after runnig migration
        var allExercises = new List<Exercise>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Push Ups"
            }
        };
        return _mapper.Map<List<ExerciseListVm>>(allExercises);
    }
}