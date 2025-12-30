using FitnessTracker.Models;

namespace FitnessTracker.Services
{
    public class WorkoutService : IWorkoutService
    {
        public IEnumerable<Workout> GetWorkouts()
        {
            return new List<Workout>
            {
                new Workout
                {
                    Title = WorkoutTitle.Peito,
                    Exercises = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "Supino",
                            Reps = 10,
                            WeightInKg = 35
                        }
                    }
                },
                new Workout
                {
                    Title = WorkoutTitle.Pernas,
                    Exercises = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "Agachamento",
                            Reps = 8,
                            WeightInKg = 20
                        }
                    }
                }
            };
        }
    }
}
