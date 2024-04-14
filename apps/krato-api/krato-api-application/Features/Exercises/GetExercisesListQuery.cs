using MediatR;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Features.Exercises;

public class GetExercisesListQuery : IRequest<List<ExerciseListVm>>
{

}