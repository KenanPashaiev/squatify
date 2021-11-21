using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseService.BL.Models.ExerciseSet;
using ExerciseService.Core;
using ExerciseService.DAL.Abstractions;

namespace ExerciseService.BL.Managers
{
    public class ExerciseSetManager : IExerciseSetManager
    {
        private readonly IMapper mapper;
        private readonly IExerciseSetRepository exerciseSetRepository;
        private readonly IExerciseTypeRepository exerciseTypeRepository;

        public ExerciseSetManager(IMapper mapper, 
            IExerciseSetRepository exerciseSetRepository,
            IExerciseTypeRepository exerciseTypeRepository)
        {
            this.mapper = mapper;
            this.exerciseSetRepository = exerciseSetRepository;
            this.exerciseTypeRepository = exerciseTypeRepository;
        }

        public async Task<ExerciseSetDto> GetExerciseSetAsync(Guid exerciseSetId)
        {
            var exerciseSet = await exerciseSetRepository.GetAsync(exerciseSetId);
            var exerciseSetDto = mapper.Map<ExerciseSetDto>(exerciseSet);
            return exerciseSetDto;
        }

        public async Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByDateRangeAsync(Guid userId, DateTime from, DateTime to)
        {
            var exerciseSets = await exerciseSetRepository.GetByDateRangeAsync(userId, from, to);
            var exerciseSetDtos = mapper.Map<IEnumerable<ExerciseSetDto>>(exerciseSets);
            return exerciseSetDtos;
        }

        public async Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByExerciseTypeAsync(Guid userId, Guid exerciseTypeId)
        {
            var exerciseSets = await exerciseSetRepository.GetByExerciseTypeAsync(userId, exerciseTypeId);
            var exerciseSetDtos = mapper.Map<IEnumerable<ExerciseSetDto>>(exerciseSets);
            return exerciseSetDtos;
        }

        public async Task<IEnumerable<ExerciseSetDto>> GetExerciseSetByExerciseTypeAsync(Guid userId, string exerciseTypeName)
        {
            var exerciseSets = await exerciseSetRepository.GetByExerciseTypeAsync(userId, exerciseTypeName);
            var exerciseSetDtos = mapper.Map<IEnumerable<ExerciseSetDto>>(exerciseSets);
            return exerciseSetDtos;
        }

        public async Task<ExerciseSetDto> AddExerciseSetAsync(ExerciseSetCreateUpdateDto exerciseSetDtoToAdd)
        {
            var exerciseSetToAdd = mapper.Map<ExerciseSet>(exerciseSetDtoToAdd);
            var exerciseType = await exerciseTypeRepository.GetAsync(exerciseSetDtoToAdd.ExerciseTypeId);
            exerciseSetToAdd.ExerciseType = exerciseType;
            var exerciseSet = await exerciseSetRepository.AddAsync(exerciseSetToAdd);
            var exerciseSetDto = mapper.Map<ExerciseSetDto>(exerciseSet);
            return exerciseSetDto;
        }

        public async Task<ExerciseSetDto> UpdateExerciseSetAsync(Guid id, ExerciseSetCreateUpdateDto exerciseSetDtoToUpdate)
        {
            var exerciseSetToUpdate = mapper.Map<ExerciseSet>(exerciseSetDtoToUpdate);
            var exerciseType = await exerciseTypeRepository.GetAsync(exerciseSetDtoToUpdate.ExerciseTypeId);
            exerciseSetToUpdate.ExerciseType = exerciseType;
            var exerciseSet = await exerciseSetRepository.UpdateAsync(id, exerciseSetToUpdate);
            var exerciseSetDto = mapper.Map<ExerciseSetDto>(exerciseSet);
            return exerciseSetDto;
        }

        public async Task<Guid> DeleteExerciseSetAsync(Guid exerciseSetId)
        {
            return await exerciseSetRepository.DeleteAsync(exerciseSetId);
        }
    }
}
