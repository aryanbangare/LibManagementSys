
using LibMinimalApi10.Persistence;
using LibMinimalApi10.Services;
using LibMinimalApi10.Web.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));


builder.Services
    .AddScoped<BooksService>()
    .AddScoped<BookIssueService>()
    .AddScoped<CategoryService>()
    .AddScoped<MemberService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

RouteGroupBuilder ApiGroup = app.MapGroup("api");

ApiGroup.MapBookEndpoints()
    .MapIssueEndpoints()
    .MapCategoryEndpoints()
    .MapMemberEndpoints();

app.MapGet("/", () => "Welcome to the Library API!");

app.Run();