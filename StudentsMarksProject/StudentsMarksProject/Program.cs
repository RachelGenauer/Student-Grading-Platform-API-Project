using GradeDO;
using Microsoft.AspNetCore.Builder;
using Serilog;
using StudentsMarksProject.Configuration1;
using StudentsMarksProject.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Configure<PercentageOfMarks>(builder.Configuration.GetSection("PercentageOfMarks"));
builder.Services.Configure<TeachersDetails>(builder.Configuration.GetSection("TeachersDetails"));
builder.Services.AddSingleton<IStudents, Students>();
builder.Services.AddSingleton<IGradeManager, GradeManager>();
builder.Services.AddSingleton<IPasswordManager, PasswordManager>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console() 
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) 
    .CreateLogger();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();
