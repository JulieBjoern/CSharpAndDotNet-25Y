namespace TodoApp.Models;

public record TaskItem(
    int Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime CreatedAt); 