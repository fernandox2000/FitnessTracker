using FitnessTracker.Data;
using FitnessTracker.Enums;
using FitnessTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly FitnessTrackerContext _context;

        public WorkoutService(FitnessTrackerContext context) => _context = context;

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync()
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .ToListAsync();
        }

        public async Task<Workout?> GetWorkoutByIdAsync(int workoutId)
        {
            return await _context.Workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(w => w.Id == workoutId);
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteWorkoutAsync(int workoutId)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);

            if (workout == null)
                return false;

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task UpdateWorkoutTitleAsync(int workoutId, WorkoutTitle title)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);

            if (workout == null)
                throw new InvalidOperationException("Workout not found");

            workout.Title = title;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllWorkouts()
        {
            await _context.Exercises.ExecuteDeleteAsync();
            await _context.Workouts.ExecuteDeleteAsync();
        }
    }
}
