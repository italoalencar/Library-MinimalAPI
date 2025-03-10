namespace Library_MinimalAPI.DTOs;

public record UpdateBookDTO(int Id, string Title, int AuthorId, string? Description, int? ReleaseYear);
