namespace TodoAppBackend.DTOs;

public record TodoItemCreateDto(string title,bool isCompleted)
{
}
