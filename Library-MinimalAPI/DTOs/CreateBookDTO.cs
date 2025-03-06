namespace Library_MinimalAPI.DTOs;

public record CreateBookDTO(string Title, int AuthorId, string? Description, int? ReleaseYear);
