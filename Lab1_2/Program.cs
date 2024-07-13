using Lab_1.Common.Filters;
using Lab_1.Common.Middlewares;
using Lab_1.Common.Services;
using Lab_1.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// builder.Services.AddEndpointsApiExplorer(); // for minimal APIs

builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<LoggingActionFilter>(); // no need if using TypeFilter

builder.Services.AddSingleton<IStudentRepo, StudentRepo>();

builder.Services.AddScoped<IObjectMapperService, ObjectMapperService>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
