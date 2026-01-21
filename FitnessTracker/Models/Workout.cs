using FitnessTracker.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Title is required.")]
        public WorkoutTitle Title { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
    }
}