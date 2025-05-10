using API.Core.Filters;
using API.Core.Middlewares;
using API.Domain.IDals;
using API.Domain.IRepos;
using API.Infrastructure.Dals;
using API.Infrastructure.Repos;
using API.Shared.Helper;

var builder = WebApplication.CreateBuilder(args);

string currentDirectory = Directory.GetCurrentDirectory();
string? rootDirectory = currentDirectory;

while (rootDirectory != null && !rootDirectory.EndsWith("API"))
{
    rootDirectory = Directory.GetParent(rootDirectory)?.FullName;
}

string dbQueryJsonPath = builder.Configuration["APIDbQueryJsonPath"]!;

string dbQueryFullPath = Path.Combine(rootDirectory ?? throw new InvalidOperationException("Root directory not found"), dbQueryJsonPath);

// Add services to the container.
builder.Services.AddScoped<DbConnectionHelper>();
builder.Services.AddSingleton(new QueryHelper(dbQueryFullPath));

builder.Services.AddScoped<ITaskDal, TaskDal>();
builder.Services.AddScoped<ITaskRepo, TaskRepo>();
builder.Services.AddScoped<IAuthDal, AuthDal>();
builder.Services.AddScoped<IAuthRepo, AuthRepo>();

// Register the ResponseWrapperFilter
builder.Services.AddScoped<ResponseWrapperFilter>();

// Add controllers with ResponseWrapperFilter globally
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResponseWrapperFilter>();
});

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<CorrelationIdMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
