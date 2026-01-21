using FitnessTracker.Enums;

namespace FitnessTracker.DTOs
{
    public class CreateWorkoutDto
    {
        public WorkoutTitle Title { get; set; } = WorkoutTitle.Peito;

        public List<CreateExerciseDto> Exercises { get; set; }
            = new() { new CreateExerciseDto() };
    }
}
