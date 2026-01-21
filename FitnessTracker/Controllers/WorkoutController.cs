using FitnessTracker.DTOs;
using FitnessTracker.Enums;
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
        public async Task<IActionResult> Post([FromBody] CreateWorkoutDto dto)
        {
            var workout = new Workout
            {
                Title = dto.Title,
                Exercises = dto.Exercises.Select(e => new Exercise
                {
                    Name = e.Name,
                    Reps = e.Reps,
                    Series = e.Series,
                    WeightInKg = e.WeightInKg
                }).ToList()
            };

            await _workoutService.AddWorkoutAsync(workout);

            return CreatedAtAction(nameof(Get), new { id = workout.Id }, workout);
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
