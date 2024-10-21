using AuthService.Data;
using AuthService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add authentication
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

// Add authorization
builder.Services.AddAuthorization();

// Add Db context
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite("DataSource=appdata.db"));

// Add Identity Core
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable Identity API
app.MapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
