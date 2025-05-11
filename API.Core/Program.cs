using System.Text;
using API.Core.Filters;
using API.Core.Middlewares;
using API.Domain.IDals;
using API.Domain.IRepos;
using API.Infrastructure.Dals;
using API.Infrastructure.Repos;
using API.Shared.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

string currentDirectory = Directory.GetCurrentDirectory();
string? rootDirectory = currentDirectory;

while (rootDirectory != null && !rootDirectory.EndsWith("API"))
{
    rootDirectory = Directory.GetParent(rootDirectory)?.FullName;
}

string dbQueryJsonPath = builder.Configuration["APIDbQueryJsonPath"]!;
string dbQueryFullPath = Path.Combine(rootDirectory ?? throw new InvalidOperationException("Root directory not found"), dbQueryJsonPath);

var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// Add services to the container.
builder.Services.AddScoped<DbConnectionHelper>();
builder.Services.AddSingleton(new QueryHelper(dbQueryFullPath));

builder.Services.AddScoped<JwtTokenHelper>();
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
