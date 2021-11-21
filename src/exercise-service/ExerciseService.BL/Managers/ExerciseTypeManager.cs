using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExerciseService.BL.Models.ExerciseType;
using ExerciseService.Core;
using ExerciseService.DAL.Abstractions;

namespace ExerciseService.BL.Managers
{
    public class ExerciseTypeManager : IExerciseTypeManager
    {
        private readonly IMapper mapper;
        private readonly IExerciseTypeRepository exerciseTypeRepository;

        public ExerciseTypeManager(IMapper mapper, 
            IExerciseTypeRepository exerciseTypeRepository)
        {
            this.mapper = mapper;
            this.exerciseTypeRepository = exerciseTypeRepository;
        }

        public async Task<ExerciseTypeDto> GetExerciseTypeAsync(Guid exerciseTypeId)
        {
            var exerciseType = await exerciseTypeRepository.GetAsync(exerciseTypeId);
            var exerciseTypeDto = mapper.Map<ExerciseTypeDto>(exerciseType);
            return exerciseTypeDto;
        }

        public async Task<ExerciseTypeDto> GetExerciseTypeByNameAsync(string name)
        {
            var exerciseType = await exerciseTypeRepository.GetByNameAsync(name);
            var exerciseTypeDto = mapper.Map<ExerciseTypeDto>(exerciseType);
            return exerciseTypeDto;
        }

        public async Task<IEnumerable<ExerciseTypeDto>> GetAllExerciseTypesAsync()
        {
            var exerciseTypes = await exerciseTypeRepository.GetAllAsync();
            var exerciseTypeDtos = mapper.Map<IEnumerable<ExerciseTypeDto>>(exerciseTypes);
            return exerciseTypeDtos;
        }

        public async Task<ExerciseTypeDto> AddExerciseTypeAsync(ExerciseTypeCreateUpdateDto exerciseTypeDtoToAdd)
        {
            var exerciseTypeToAdd = mapper.Map<ExerciseType>(exerciseTypeDtoToAdd);
            exerciseTypeToAdd.CreatedDate = DateTime.UtcNow;
            var exerciseType = await exerciseTypeRepository.AddAsync(exerciseTypeToAdd);
            var exerciseTypeDto = mapper.Map<ExerciseTypeDto>(exerciseType);
            return exerciseTypeDto;
        }

        public async Task<ExerciseTypeDto> UpdateExerciseTypeAsync(Guid exerciseTypeId, ExerciseTypeCreateUpdateDto exerciseTypeDtoToUpdate)
        {
            var exerciseTypeToUpdate = mapper.Map<ExerciseType>(exerciseTypeDtoToUpdate);
            var exerciseType = await exerciseTypeRepository.UpdateAsync(exerciseTypeId, exerciseTypeToUpdate);
            var exerciseTypeDto = mapper.Map<ExerciseTypeDto>(exerciseType);
            return exerciseTypeDto;
        }

        public async Task<Guid> DeleteExerciseTypeAsync(Guid exerciseTypeId)
        {
            return await exerciseTypeRepository.DeleteAsync(exerciseTypeId);
        }
    }
}
