
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Features.Exercises;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApi.Controllers;

[ApiController]
[Route("exercise")]
public class ExerciseController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExerciseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllExercises")]
    public async Task<ActionResult<List<ExerciseListVm>>> GetAllExercises()
    {
        var dtos = await _mediator.Send(new GetExercisesListQuery());
        return Ok(dtos);
    }
}