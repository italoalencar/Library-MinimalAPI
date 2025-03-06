using Library_MinimalAPI.DTOs;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Mvc;
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
            var user = await _service.LoginUser(login);
            return Results.Ok();
        });
    }
}
