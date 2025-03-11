using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Library_MinimalAPI.Endpoints;

public static class CustomerEndpoints
{
    public static void AddCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("users")
            .WithTags("User/Customer");

        group.MapPost("create", async (CustomerService _service, [FromBody] CreateCustomerDTO customerDTO) =>
        {
            var result = await _service.CreateUser(customerDTO);
            if (result.Succeeded) return Results.Ok("User created!");
            return Results.BadRequest("Failed to create user.");

        });

        group.MapPost("login", async (CustomerService _service, LoginDTO login) =>
        {
            var token = await _service.LoginUser(login);
            return Results.Ok(token);
        });

        group.MapGet("whoami", (CustomerService _service, HttpContext httpContext) =>
        {
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null) return Results.BadRequest("No login!!!");
            var name = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var role = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            return Results.Ok(new {userId, name, role = role ?? "user" });
        }).RequireAuthorization();
    }
}
