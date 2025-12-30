using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public interface IWorkoutService
    {
        IEnumerable<Workout> GetWorkouts();
    }
}
