using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();

    var retries = 30;

    while (retries > 0)
    {
        try
        {
            if (await db.Database.CanConnectAsync())
            {
                await db.Database.EnsureCreatedAsync();
                break;
            }
        }
        catch
        {
        }

        retries--;
        await Task.Delay(2000);
    }

    if (retries == 0)
    {
        throw new Exception("Не удалось подключиться к PostgreSQL.");
    }
}

app.MapGet("/health", () =>
    Results.Ok(new { status = "OK" }));

app.MapGet("/tasks", async (TaskDbContext db) =>
    await db.Tasks
        .OrderBy(t => t.Id)
        .ToListAsync());

app.MapGet("/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);

    return task is null
        ? Results.NotFound()
        : Results.Ok(task);
});

app.MapPost("/tasks", async (TaskItem task, TaskDbContext db) =>
{
    task.Id = 0;

    db.Tasks.Add(task);
    await db.SaveChangesAsync();

    return Results.Created($"/tasks/{task.Id}", task);
});

app.MapPut("/tasks/{id:int}", async (int id, TaskItem updatedTask, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);

    if (task is null)
        return Results.NotFound();

    task.Title = updatedTask.Title;
    task.Completed = updatedTask.Completed;

    await db.SaveChangesAsync();

    return Results.Ok(task);
});

app.MapDelete("/tasks/{id:int}", async (int id, TaskDbContext db) =>
{
    var task = await db.Tasks.FindAsync(id);

    if (task is null)
        return Results.NotFound();

    db.Tasks.Remove(task);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public bool Completed { get; set; }
}