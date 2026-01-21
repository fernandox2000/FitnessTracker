using FitnessTracker.Enums;

namespace FitnessTracker.DTOs
{
    public class CreateExerciseDto
    {
        public ExerciseName Name { get; set; } = ExerciseName.SupinoReto;

        public int Reps { get; set; } = 12;

        public int Series { get; set; } = 3;

        public double WeightInKg { get; set; } = 0;
    }
}
