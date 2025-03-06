namespace Library_MinimalAPI.DTOs;

public record ReadBookDTO(int Id, string Title, int AuthorId, string? Description, int? ReleaseYear);
