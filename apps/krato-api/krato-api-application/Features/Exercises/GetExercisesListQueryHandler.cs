
using AutoMapper;
using MediatR;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Contracts.Persistence;

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
        var allExercises = await _exerciseRepo.ListAllAsync();
        return _mapper.Map<List<ExerciseListVm>>(allExercises);
    }
}