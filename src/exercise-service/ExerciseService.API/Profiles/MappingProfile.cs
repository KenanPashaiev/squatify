using AutoMapper;
using ExerciseService.BL.Models.ExerciseSet;
using ExerciseService.BL.Models.ExerciseType;
using ExerciseService.Core;

namespace ExerciseService.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExerciseSet, ExerciseSetDto>().ReverseMap();
            CreateMap<ExerciseSetCreateUpdateDto, ExerciseSet>();

            CreateMap<ExerciseType, ExerciseTypeDto>().ReverseMap();
            CreateMap<ExerciseTypeCreateUpdateDto, ExerciseType>();
        }
    }
}