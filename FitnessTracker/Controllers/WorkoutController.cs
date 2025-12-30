using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;

namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {

        private readonly ILogger<WorkoutController> _logger;

        public WorkoutController(ILogger<WorkoutController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWorkouts")]
        public IEnumerable<Workout> Get()
        {
            var workouts = new List<Workout>
            {
                new Workout
                {
                    Title = WorkoutTitle.Peito,
                    Exercises = new List<Exercise>
                    {
                        new Exercise()
                        {
                            Name = "Supino",
                            Reps = 10,
                            WeightInKg = 35
                        }
                    }
                },
                new Workout()
                {
                    Title = WorkoutTitle.Pernas,
                    Exercises = new List<Exercise>
                    {
                        new Exercise()
                        {
                            Name = "Agachamento",
                            Reps = 8,
                            WeightInKg = 20
                        }
                    }
                }
            };

            return workouts;
        }

    }
}
