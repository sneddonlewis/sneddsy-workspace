using AutoMapper;
using SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Features.Exercises;
using SneddsyWorkspace.Apps.KratoApi.KratoApiDomain.Entities;

namespace SneddsyWorkspace.Apps.KratoApi.KratoApiApplication.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Exercise, ExerciseListVm>().ReverseMap();
    }
}