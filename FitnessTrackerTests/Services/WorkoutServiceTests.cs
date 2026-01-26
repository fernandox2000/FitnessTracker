using FitnessTracker.Data;
using FitnessTracker.Enums;
using FitnessTracker.Models;
using FitnessTracker.Services;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerTests.Services
{
    public class WorkoutServiceTests
    {
        private FitnessTrackerContext _context;
        private WorkoutService _workoutService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FitnessTrackerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new FitnessTrackerContext(options);
            _workoutService = new WorkoutService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AddWorkoutAsync_ShouldAddWorkout()
        {
            // Arrange
            var workout = new Workout
            {
                Title = WorkoutTitle.Peito
            };

            // Act
            await _workoutService.AddWorkoutAsync(workout);

            // Assert
            var workoutsInDb = await _context.Workouts.ToListAsync();

            Assert.That(workoutsInDb.Count, Is.EqualTo(1));
            Assert.That(workoutsInDb[0].Title, Is.EqualTo(WorkoutTitle.Peito));
        }

        [Test]
        public async Task GetWorkoutAsync_ShouldReturnWorkouts()
        {
            // Arrange
            var workout = new Workout
            {
                Title = WorkoutTitle.Peito,
                Exercises = new List<Exercise>
                {
                    new Exercise
                    {
                        Name = ExerciseName.SupinoReto,
                        Reps = 10,
                        Series = 3,
                        WeightInKg = 40
                    }
                }
            };
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            // Act
            var result = await _workoutService.GetWorkoutsAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First().Title, Is.EqualTo(WorkoutTitle.Peito));
            Assert.That(result.First().Exercises.Count, Is.EqualTo(1));
        }
    }
}
