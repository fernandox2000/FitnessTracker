using System.Text.Json.Serialization;

namespace FitnessTracker.Models;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Reps { get; set; }
    public double WeightInKg { get; set; }
}