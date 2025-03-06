using Library_MinimalAPI.DAL;
using Library_MinimalAPI.Data;
using Library_MinimalAPI.Endpoints;
using Library_MinimalAPI.Models;
using Library_MinimalAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration["LibraryDB"])
    .UseLazyLoadingProxies());

builder.Services.AddIdentity<Customer, IdentityRole>()
    .AddEntityFrameworkStores<LibraryContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(DAL<>));

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddAuthorEndpoints();
app.AddBookEndpoints();
app.AddCustomerEndpoints();

app.Run();
