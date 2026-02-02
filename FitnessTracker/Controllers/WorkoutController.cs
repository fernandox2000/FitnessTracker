using FitnessTracker.DTOs;
using FitnessTracker.Enums;
using FitnessTracker.Factories;
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
        private readonly IWorkoutFactory _workoutFactory;

        public WorkoutController(
            ILogger<WorkoutController> logger,
            IWorkoutService workoutService,
            IWorkoutFactory workoutFactory)
        {
            _logger = logger;
            _workoutService = workoutService;
            _workoutFactory = workoutFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> Get()
        {
            var workouts = await _workoutService.GetWorkoutsAsync();
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetById(int id)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(id);

            if (workout == null)
                return NotFound();

            return Ok(workout);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkoutDto dto)
        {
            var workout = _workoutFactory.CreateWorkout(dto);

            await _workoutService.AddWorkoutAsync(workout);

            return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _workoutService.DeleteWorkoutAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] WorkoutTitle title)
        {
            try
            {
                await _workoutService.UpdateWorkoutTitleAsync(id, title);
                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteAllWorkouts()
        {
            await _workoutService.DeleteAllWorkouts();

            return NoContent();
        }
    }
}
