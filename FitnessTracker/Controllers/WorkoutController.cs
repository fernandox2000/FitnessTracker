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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> Get()
        {
            return Ok(await _workoutService.GetWorkoutsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Workout workout)
        {
            await _workoutService.AddWorkoutAsync(workout);
            return CreatedAtAction(nameof(Get), workout);
        }

    }
}
