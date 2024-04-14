
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

    public Task<List<ExerciseListVm>> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
    {
        // this is where we add the business logic
        var result = new List<ExerciseListVm>()
        {
            new ExerciseListVm { Name = "Push Up" }     
        };
        return Task.FromResult<List<ExerciseListVm>>(result);
    }
}