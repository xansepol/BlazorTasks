using BlazorTasks.API.Configuration;
using BlazorTasks.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite("Data Source=task.db");
});
builder.Services.AddServiceConfiguration();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    options =>
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("https://localhost:7014").AllowAnyMethod().AllowAnyHeader();
            }
        )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
