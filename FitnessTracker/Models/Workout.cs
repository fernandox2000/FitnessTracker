namespace FitnessTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public WorkoutTitle Title { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
    }
}