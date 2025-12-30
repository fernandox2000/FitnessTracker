using FitnessTracker.Models;
using FitnessTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {

        private readonly ILogger<WorkoutController> _logger;
        private readonly IWorkoutService _workoutService;

        public WorkoutController(
            ILogger<WorkoutController> logger,
            IWorkoutService workoutService)
        {
            _logger = logger;
            _workoutService = workoutService;
        }

        [HttpGet(Name = "GetWorkouts")]
        public ActionResult<IEnumerable<Workout>> Get()
        {
            var workouts = _workoutService.GetWorkouts();
            return Ok(workouts);
        }

    }
}
