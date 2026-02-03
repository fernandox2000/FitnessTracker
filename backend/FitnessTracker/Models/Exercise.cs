using FitnessTracker.Enums;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models;

public class Exercise
{
    public int Id { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Title is required.")]
    public ExerciseName Name { get; set; } = ExerciseName.SupinoReto;

    [Range(1, int.MaxValue, ErrorMessage = "Reps must be positive.")]
    public int Reps { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Series must be positive.")]
    public int Series { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "Weight must be positive.")]
    public double WeightInKg { get; set; }
}