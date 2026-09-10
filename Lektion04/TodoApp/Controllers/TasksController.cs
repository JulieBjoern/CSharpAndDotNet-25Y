using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TasksController : ControllerBase
{
    private List<TaskItem> Tasks { get; } = 
        [
            new TaskItem(1, "Opret API", "Opret en API med C# og .NET 10", false, DateTime.Now),
            new TaskItem(2, "C# syntax", "Bliv bedre til C# syntax og brug af .NET", false, DateTime.Now),
            new TaskItem(3, "Luft Mame", "Gå en tur ovre i skoven med Bønnen", true, DateTime.Now), 
        ];
    
    
    [HttpGet]
    public IActionResult Get(bool? isCompleted) // kan også være public ActionResult<List<TaskItem>> get() forskellen er at IActionResult er mere generel
                               // og kan returnere forskellige typer svar, mens ActionResult<List<TaskItem>> er mere specifik og indikerer,
                               // at metoden returnerer en liste af TaskItems.
    {
        if (isCompleted.HasValue) // Tjekker om isCompleted parameteren har en værdi (ikke null).
        {
            var filteredTasks = Tasks.Where(t => t.IsCompleted == isCompleted.Value).ToList(); // Filtrerer listen af TaskItems baseret på isCompleted værdien.
            return Ok(filteredTasks); // Returnerer en HTTP 200 OK statuskode sammen med den filtrerede liste som JSON.
        }
        return Ok(Tasks); // Returnerer en HTTP 200 OK statuskode sammen med listen af TaskItems som JSON.
    }
    
    // Hent et enkelt item
    [HttpGet]
    [Route("{id:int}")] // Angiver, at id'et skal være et heltal (int) i URL'en.
    [ProducesResponseType(StatusCodes.Status200OK)] // Angiver, at metoden kan returnere en HTTP 200 OK statuskode.
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Angiver, at metoden kan returnere en HTTP 404 Not Found statuskode.
    public ActionResult<TaskItem> Get(int id)
    {
        if (id < 0 || id >= Tasks.Count -1)
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis id'et er uden for rækkevidde.
        }
        return Ok(Tasks[id]);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create(CreateTaskDto createTaskDto)
    {
        var newTask = new TaskItem(
            Id: Tasks.Count + 1,
            Title: createTaskDto.Title,
            Description: createTaskDto.Description,
            IsCompleted: createTaskDto.IsCompleted,
            CreatedAt: DateTime.Now
        );
        
        Tasks.Add(newTask);
        
        // nameof(Get) betyder at vi refererer til Get metoden i denne controller, så vi kan bruge den til at generere URL'en til den nye ressource.
        return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask); // Returnerer en HTTP 201 Created statuskode sammen med den nye TaskItem som JSON.
    }
    
    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, UpdateTaskDto updateTaskDto)
    {
        if (id < 0 || id >= Tasks.Count -1)
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis id'et er uden for rækkevidde.
        }

        var task = Tasks[id];
        Tasks[id] = new TaskItem(
            Id: id,
            Title: updateTaskDto.Title,
            Description: updateTaskDto.Description,
            IsCompleted: updateTaskDto.IsCompleted,
            CreatedAt: task.CreatedAt
        );

        return Ok(Tasks[id]);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (id < 0 || id >= Tasks.Count -1)
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis id'et er uden for rækkevidde.
        }

        Tasks.RemoveAt(id);
        return NoContent(); // Returnerer en HTTP 204 No Content statuskode, hvilket indikerer, at sletningen var vellykket, men der er ingen indhold at returnere.
    }

}