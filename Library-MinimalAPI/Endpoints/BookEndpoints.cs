using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_MinimalAPI.Endpoints;

public static class BookEndpoints
{
    public static void AddBookEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("books")
            .WithTags("Books");

        group.MapPost("", (BookService _service, [FromBody] CreateBookDTO bookDTO) =>
        {
            return Results.Ok(_service.Create(bookDTO));
        });

        group.MapGet("", (BookService _service) =>
        {
         return Results.Ok(_service.GetAll());
        });

        group.MapGet("{id}", (BookService _service, int id) =>
        {
            var bookDTO = _service.GetById(id);
            if (bookDTO is null) return Results.NotFound("Book not found.");
            return Results.Ok(bookDTO);
        });

        group.MapPut("", (BookService _service, [FromBody] ReadBookDTO bookDTO) =>
        {
            var wasUpdated = _service.Update(bookDTO);
            if (wasUpdated) return Results.NoContent(); 
            return Results.NotFound("Book not found.");
        });

        group.MapDelete("{id}", (BookService _service, int id) =>
        {
            var wasDeleted = _service.Delete(id);
            if (wasDeleted) return Results.NoContent();
            return Results.NotFound("Book not found.");
        });
    }
}
