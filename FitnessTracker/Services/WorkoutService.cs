using FitnessTracker.Data;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly FitnessTrackerContext _context;

        public WorkoutService(FitnessTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync()
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .ToListAsync();
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }
    }
}
