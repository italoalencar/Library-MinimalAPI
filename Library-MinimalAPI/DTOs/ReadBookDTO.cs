namespace Library_MinimalAPI.DTOs;

public record ReadBookDTO(int Id, string Title, string? Description, int? ReleaseYear, ReadAuthorDTO Author);
