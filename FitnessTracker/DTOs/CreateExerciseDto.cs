using FitnessTracker.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.DTOs
{
    public class CreateExerciseDto
    {
        [Required]
        public ExerciseName Name { get; set; }

        [Range(1, 100)]
        public int Reps { get; set; }

        [Range(1, 20)]
        public int Series { get; set; }

        [Range(0, 1000)]
        public double WeightInKg { get; set; }
    }
}
