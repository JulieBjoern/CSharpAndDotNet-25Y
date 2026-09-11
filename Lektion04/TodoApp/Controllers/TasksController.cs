using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TasksController : ControllerBase
{
    // ITaskService leveres via dependency injection (registreret med AddSingleton i Program.cs).
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult Get(bool? isCompleted) // kan også være public ActionResult<List<TaskItem>> get() forskellen er at IActionResult er mere generel
                               // og kan returnere forskellige typer svar, mens ActionResult<List<TaskItem>> er mere specifik og indikerer,
                               // at metoden returnerer en liste af TaskItems.
    {
        return Ok(_taskService.GetAll(isCompleted)); // Returnerer en HTTP 200 OK statuskode sammen med listen af TaskItems som JSON.
    }

    // Hent et enkelt item
    [HttpGet]
    [Route("{id:int}")] // Angiver, at id'et skal være et heltal (int) i URL'en.
    [ProducesResponseType(StatusCodes.Status200OK)] // Angiver, at metoden kan returnere en HTTP 200 OK statuskode.
    [ProducesResponseType(StatusCodes.Status404NotFound)] // Angiver, at metoden kan returnere en HTTP 404 Not Found statuskode.
    public ActionResult<TaskItem> Get(int id)
    {
        var task = _taskService.GetById(id);
        if (task is null)
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis der ikke findes et item med det givne id.
        }
        return Ok(task);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Create(CreateTaskDto createTaskDto)
    {
        var newTask = _taskService.Create(createTaskDto);

        // nameof(Get) betyder at vi refererer til Get metoden i denne controller, så vi kan bruge den til at generere URL'en til den nye ressource.
        return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask); // Returnerer en HTTP 201 Created statuskode sammen med den nye TaskItem som JSON.
    }

    [HttpPut]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(int id, UpdateTaskDto updateTaskDto)
    {
        var task = _taskService.Update(id, updateTaskDto);
        if (task is null)
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis der ikke findes et item med det givne id.
        }

        return Ok(task);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (!_taskService.Delete(id))
        {
            return NotFound(); // Returnerer en HTTP 404 Not Found statuskode, hvis der ikke findes et item med det givne id.
        }

        return NoContent(); // Returnerer en HTTP 204 No Content statuskode, hvilket indikerer, at sletningen var vellykket, men der er ingen indhold at returnere.
    }

}
