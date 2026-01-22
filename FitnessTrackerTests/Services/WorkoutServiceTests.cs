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
    }
}
