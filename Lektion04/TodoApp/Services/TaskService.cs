using TodoApp.Models;

namespace TodoApp.Services;

// Registreret som singleton i Program.cs (AddSingleton): én instans deles mellem ALLE requests
// i hele app'ens levetid. Derfor overlever listen mellem requests - modsat tidligere, hvor
// listen lå i controlleren og blev nulstillet ved hvert request.
public class TaskService : ITaskService
{
    
    // Bemærk: en singleton deles mellem tråde, så hvis flere requests skriver samtidig,
    // skal listen beskyttes med f.eks. lock eller ConcurrentDictionary.
    private readonly List<TaskItem> _tasks =
    [
        new TaskItem(1, "Opret API", "Opret en API med C# og .NET 10", false, DateTime.Now),
        new TaskItem(2, "C# syntax", "Bliv bedre til C# syntax og brug af .NET", false, DateTime.Now),
        new TaskItem(3, "Luft Mame", "Gå en tur ovre i skoven med Bønnen", true, DateTime.Now),
    ];

    public List<TaskItem> GetAll(bool? isCompleted)
    {
        if (isCompleted.HasValue) // Tjekker om isCompleted parameteren har en værdi (ikke null).
        {
            // Filtrerer listen af TaskItems baseret på isCompleted værdien.
            return _tasks.Where(t => t.IsCompleted == isCompleted.Value).ToList();
        }
        return _tasks;
    }

    // Vi slår op på t.Id i stedet for at bruge index i listen - id og placering i listen
    // er nemlig ikke nødvendigvis det samme (f.eks. efter et Delete).
    public TaskItem? GetById(int id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem Create(CreateTaskDto createTaskDto)
    {
        var newTask = new TaskItem(
            // Max + 1 i stedet for Count + 1: efter et Delete kan Count + 1 give et id, der allerede findes.
            Id: _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1,
            Title: createTaskDto.Title,
            Description: createTaskDto.Description,
            IsCompleted: createTaskDto.IsCompleted,
            CreatedAt: DateTime.Now
        );

        _tasks.Add(newTask);
        return newTask;
    }

    public TaskItem? Update(int id, UpdateTaskDto updateTaskDto)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
        {
            return null; // null betyder "ikke fundet" - controlleren returnerer så 404.
        }

        // "with" er en record-funktion: kopierer task'en og ændrer kun de angivne properties
        // (Id og CreatedAt bevares automatisk).
        var updatedTask = task with
        {
            Title = updateTaskDto.Title,
            Description = updateTaskDto.Description,
            IsCompleted = updateTaskDto.IsCompleted,
        };

        _tasks[_tasks.IndexOf(task)] = updatedTask;
        return updatedTask;
    }

    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
        {
            return false;
        }

        _tasks.Remove(task);
        return true;
    }
}
