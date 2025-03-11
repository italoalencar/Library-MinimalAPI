using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_MinimalAPI.Endpoints;

public static class AuthorEndpoints
{
    public static void AddAuthorEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/authors")
            .WithTags("Authors");

        group.MapPost("", (AuthorService _service, [FromBody] CreateAuthorDTO authorDTO) =>
        {
            return Results.Ok(_service.Create(authorDTO));
        }).RequireAuthorization("AdminOnly");

        group.MapGet("", (AuthorService _service) =>
        {
            return Results.Ok(_service.GetAll());
        });

        group.MapGet("{id}", (AuthorService _service, int id) =>
        {
            var authorDTO = _service.GetById(id);
            if (authorDTO is null) return Results.NotFound("Author not found.");
            return Results.Ok(authorDTO);
        });

        group.MapPut("", (AuthorService _service, [FromBody] ReadAuthorDTO authorDTO) =>
        {
            var wasUpdated = _service.Update(authorDTO);
            if (wasUpdated) return Results.NoContent();
            return Results.NotFound("Author not found.");
        }).RequireAuthorization("AdminOnly");

        group.MapDelete("{id}", (AuthorService _service, int id) =>
        {
            var wasRemoved = _service.Delete(id);
            if (wasRemoved) return Results.NoContent();
            return Results.NotFound("Author not found.");
        }).RequireAuthorization("AdminOnly");
    }
}
