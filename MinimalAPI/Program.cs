using DataLib;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ToDoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/

// add minimal API code here..
// or refactor into other classes (when api grows).

app.MapGet(pattern: "/todo-list", handler: ([FromServices] ToDoRepository repo) => {
    return repo.GetAll();
});

app.MapGet(pattern: "/todo-list/{id}", handler: ([FromServices] ToDoRepository repo, long id) => {
    var toDoItem = repo.GetById(id);
    return toDoItem is not null ? Results.Ok(toDoItem) : Results.NotFound();
});

app.MapPost("/todo-list", ([FromServices] ToDoRepository repo, ToDoItem item) => {
    repo.Create(item);
    return Results.Created($"/todo-list/{item.Id}", item);
});

app.MapPut("/todo-list/{id}", ([FromServices] ToDoRepository repo, long id, ToDoItem updatedItem) => {
    var toDoItem = repo.GetById(id);
    if (updatedItem is null)
    {
        return Results.NotFound();
    }
    repo.Update(id, updatedItem);
    return Results.Ok(updatedItem);
});

app.MapDelete("/todo-list/{id}", ([FromServices] ToDoRepository repo, long id) =>
{
    repo.Delete(id);
    return Results.Ok();
});
app.Run();