namespace TodoApp.Models;

public record UpdateTaskDto(string Title, string? Description, bool IsCompleted);