using FitnessTracker.DTOs;
using FitnessTracker.Models;

namespace FitnessTracker.Factories
{
    public interface IWorkoutFactory
    {
        Workout CreateWorkout(CreateWorkoutDto dto);
    }
}
