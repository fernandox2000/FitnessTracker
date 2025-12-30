namespace FitnessTracker.Models
{
    public class Workout
    {
        public WorkoutTitle Title { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
    }

}