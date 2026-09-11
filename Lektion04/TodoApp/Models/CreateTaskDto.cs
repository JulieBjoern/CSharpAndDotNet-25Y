using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models;

public record CreateTaskDto(
    [Required]
    [StringLength(50)] 
    string Title, 
    [StringLength(200)]
    string? Description, 
    bool IsCompleted
    );