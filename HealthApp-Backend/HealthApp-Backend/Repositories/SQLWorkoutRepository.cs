using HealthApp_Backend.Data;
using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Repositories;

public class SQLWorkoutRepository : IWorkoutRepository
{
    private readonly HealthAppDbContext dbContext;

    
    public SQLWorkoutRepository(HealthAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    
    public async Task<List<Workout>> getWorkoutDataByUserIdAsync(Guid userId)
    {
        return await dbContext.Workouts
            .Where(w => w.userId == userId) // Filter by userId
            .Include(w => w.Exercises)      // Include related Exercises
            .ThenInclude(e => e.Sets)   // Include Sets for each Exercise
            .ToListAsync();                 // Execute asynchronously
    }

    private Workout MakeWorkout(Guid userId, string name)
    {
        Workout workout = new Workout()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Date = DateTime.Now,
            userId = userId
        };
        return workout;

    }
    
    
    private Exercise MakeExercise(Guid workoutId, string name, Guid userId)
    {
        Exercise exercise = new Exercise()
        {
            Id = Guid.NewGuid(),
            Name = name,
            WorkoutId = workoutId,
            userId = userId
        };
        return exercise;
    }
    
    private Set MakeSet(Guid exerciseId, int reps, decimal weight, Guid userId)
    {
        Set set = new Set()
        {
            Id = Guid.NewGuid(),
            ExerciseId = exerciseId,
            Reps = reps,
            Weight = weight,
            userId = userId
        };
        return set;
    }
    
    

    public async Task<Workout> AddWorkout(Guid userId, string name)
    {
        var workout = MakeWorkout(userId, name);
        await dbContext.Workouts.AddAsync(workout);
        await dbContext.SaveChangesAsync();
        return workout;
    }

    public Task<Workout?> getWorkoutDataByWorkoutIdAsync(Guid workoutId, Guid userId)
    {
        return dbContext.Workouts
            .Where(w => w.Id == workoutId && w.userId == userId)
            .Include(w => w.Exercises)
            .ThenInclude(e => e.Sets)
            .FirstOrDefaultAsync();
    }

    public async Task<Exercise> AddExercise(Guid workoutId, string name, Guid userId)
    {
        var exercise = MakeExercise(workoutId, name, userId);
        await dbContext.Exercises.AddAsync(exercise);
        await dbContext.SaveChangesAsync();
        return exercise;
    }

    public Task<Set> AddSet(Guid exerciseId, int reps, decimal weight, Guid userId)
    {
        var set = MakeSet(exerciseId, reps, weight, userId);
        dbContext.Sets.Add(set);
        dbContext.SaveChanges();
        return Task.FromResult(set);
    }

    public async Task<Set?> UpdateSet(UpdateSetDto addSetDto, Guid userId)
    {
        var set = await dbContext.Sets.FirstOrDefaultAsync(s => s.Id == addSetDto.Id && s.userId == userId);
        if (set == null)
        {
            return null;
        }

        set.Reps = addSetDto.Reps;
        set.Weight = addSetDto.Weight;
        await dbContext.SaveChangesAsync();
        return set;
    }

    public async Task<Set?> DeleteSet(Guid setId, Guid userId)
    {
        var set = await dbContext.Sets.FirstOrDefaultAsync(s => s.Id == setId && s.userId == userId);
        if (set == null)
        {
            return null;
        }
        var deletedSet = dbContext.Sets.Remove(set);
        await dbContext.SaveChangesAsync();
        return set;
    }

    public async Task<Exercise?> DeleteExercise(Guid exerciseId, Guid userId)
    {
       
        
        var exercise = await dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId && e.userId == userId);
        if (exercise == null)
        {
            return null;
        }
        dbContext.Sets.RemoveRange(exercise.Sets);

        
        dbContext.Exercises.Remove(exercise);
        
        await dbContext.SaveChangesAsync();

        return exercise;
    }

    public async Task<Workout?> DeleteWorkout(Guid workoutId, Guid userId)
    {
        Console.WriteLine($"UserId: {userId}");

        try
        {
            var workout = await dbContext.Workouts
                .Include(w => w.Exercises)
                .ThenInclude(e => e.Sets) 
                .FirstOrDefaultAsync(w => w.Id == workoutId && w.userId == userId);
            Console.WriteLine($"workout: {workout}");
            
            if (workout == null)
            {
                return null;
            }
            foreach (var exercise in workout.Exercises)
            {
                dbContext.Sets.RemoveRange(exercise.Sets);
            }
            dbContext.Exercises.RemoveRange(workout.Exercises);
            dbContext.Workouts.Remove(workout);
            await dbContext.SaveChangesAsync();

            return workout;
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error deleting workout: {ex.Message}");
            return null; 
        }
    }

}