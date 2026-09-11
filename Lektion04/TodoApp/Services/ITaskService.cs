using TodoApp.Models;

namespace TodoApp.Services;

// Interfacet gør, at controlleren kun afhænger af kontrakten og ikke af implementationen.
// Det gør det nemt senere at skifte TaskService ud med f.eks. en database-baseret service.
public interface ITaskService
{
    List<TaskItem> GetAll(bool? isCompleted);
    TaskItem? GetById(int id);
    TaskItem Create(CreateTaskDto createTaskDto);
    TaskItem? Update(int id, UpdateTaskDto updateTaskDto);
    bool Delete(int id);
}
