using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library_MinimalAPI.Endpoints;

public static class LoanEndpoint
{
    public static void AddLoanEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("loans")
            .WithTags("Loans");

        group.MapPost("", (LoanService _service, HttpContext httpContext, [FromBody] CreateLoanDTO loanDTO) =>
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null) return Results.Unauthorized();

            var created = _service.Create(userId, loanDTO);
            if (created) return Results.NoContent();
            return Results.BadRequest("Could not create loan.");
        });

        group.MapGet("", (LoanService _service, HttpContext httpContext) =>
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null) return Results.Unauthorized();

            var loans = _service.ReadByUser(userId);
            return Results.Ok(loans);
        });

        // admin
        group.MapGet("/users", (LoanService _service, string? userId) =>
        {
            ICollection<ReadLoanDTO> loans = [];
            if (userId is not null)
            {
                loans = _service.ReadByUser(userId);
            }
            else
            {
                loans = _service.ReadAll();
            }
            
            return Results.Ok(loans);
        }).RequireAuthorization("AdminOnly");

        group.MapPatch("{id}", (LoanService _service, [FromBody] UpdateLoanDTO loanDTO, int id) =>
        {
            var updated = _service.UpdateStatus(id, loanDTO);
            if (updated) return Results.NoContent();
            return Results.NotFound("Loan not found.");
        }).RequireAuthorization("AdminOnly");
    }
}
