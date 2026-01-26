using FitnessTracker.Enums;
using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetWorkoutsAsync();
        Task<Workout?> GetWorkoutByIdAsync(int workoutId);
        Task AddWorkoutAsync(Workout workout);
        Task<bool> DeleteWorkoutAsync(int workoutId);
        Task UpdateWorkoutTitleAsync(int workoutId, WorkoutTitle title);
        Task DeleteAllWorkouts();
    }
}
