using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public interface IWorkoutService
    {
        Task<IEnumerable<Workout>> GetWorkoutsAsync();
        Task AddWorkoutAsync(Workout workout);
    }
}
