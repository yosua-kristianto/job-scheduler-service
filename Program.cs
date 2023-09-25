using etl_job_service.Config;
using etl_job_service.Handler;
using etl_job_service.Repository.Img;
using etl_job_service.Repository.Job;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Load Environment Variables
Dictionary<string, string> mapEnvKey()
{
    // @todo: Make it more dynamic

    return new() {
        { EnvironmentVariableConstant.environmentVariables["DefaultFileStoragePath"], builder.Configuration.GetValue<string>("DefaultFileStoragePath")}
    };
}

EnvironmentVariables.Instance(mapEnvKey());

// Registering Database Connection to Dependency Injection
builder.Services.AddDbContext<DatabaseContext>(
    options =>
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version())
));


// Registering Handler to Dependency Injection
builder.Services.AddScoped<IOcrSchedulerControllerHandler, OcrSchedulerControllerHandler>();

// Registering Repository to Dependency Injection
builder.Services.AddScoped<IImageProfileRepository, ImageProfileRepository>();
builder.Services.AddScoped<IJobSchedulerRepository, JobSchedulerRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// See the .NET Console for fun.
System.Console.WriteLine("  _____ _____ _        ____            _             _ _           \r\n | ____|_   _| |      / ___|___  _ __ | |_ _ __ ___ | | | ___ _ __ \r\n |  _|   | | | |     | |   / _ \\| '_ \\| __| '__/ _ \\| | |/ _ \\ '__|\r\n | |___  | | | |___  | |__| (_) | | | | |_| | | (_) | | |  __/ |   \r\n |_____| |_| |_____|  \\____\\___/|_| |_|\\__|_|  \\___/|_|_|\\___|_|   \r\n                                                                   ");

app.Run();
