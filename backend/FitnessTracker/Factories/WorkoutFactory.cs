using FitnessTracker.DTOs;
using FitnessTracker.Models;

namespace FitnessTracker.Factories
{
    public class WorkoutFactory : IWorkoutFactory
    {
        public Workout CreateWorkout(CreateWorkoutDto dto)
        {
            var workout = new Workout
            {
                Title = dto.Title,
                Exercises = new List<Exercise>()
            };

            foreach (var e in dto.Exercises)
            {
                workout.Exercises.Add(new Exercise
                {
                    Name = e.Name,
                    Reps = e.Reps,
                    Series = e.Series,
                    WeightInKg = e.WeightInKg
                });
            }

            return workout;
        }
    }
}
