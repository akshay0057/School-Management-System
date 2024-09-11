using Microsoft.EntityFrameworkCore;
using Middlewares;
using SMSAPIProject.Database_Models;
using SMSAPIProject.Services;
using SMSAPIProject.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure Database
builder.Services.AddDbContext<SMS_Dev_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IMasterService, MasterService>();
builder.Services.AddTransient<ITeacherService, TeacherService>();
builder.Services.AddTransient<IAttendenceService, AttendenceService>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Add Middleware Type to Application's Request pipeline
//app.UseMiddleware<TokenValidationMiddleware>();
//app.UseMiddleware<CustomHeaderMiddleware>();

app.MapControllers();

app.Run();
