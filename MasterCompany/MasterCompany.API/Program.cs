using MasterCompany.Business.Services;
using MasterCompany.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar la ruta del archivo .txt
var filePath = Path.Combine(builder.Environment.ContentRootPath, "Data", "employees.txt");

// Inyección de dependencias
builder.Services.AddSingleton<IEmployeeRepository>(new EmployeeRepository(filePath));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS para Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();