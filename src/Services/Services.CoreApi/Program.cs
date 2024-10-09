using System.Reflection;

using devdeer.ListOfWork.Logic.Core;
using devdeer.ListOfWork.Logic.Interfaces;
using devdeer.ListOfWork.Repositories.Mock;
using devdeer.ListOfWork.Services.CoreApi.Middlewares;

using Microsoft.OpenApi.Models;

var policyName = "_AllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                      });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Version = "v1",
                Title = "The API for the ListOfWork app",
                Description = "An API to handle the todos inside of the ListOfWork app.",
                Contact = new OpenApiContact
                {
                    Name = "Contact us",
                    Url = new Uri("https://devdeer.com")
                }
            });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    });
builder.Services.AddTransient<ITodoListLogic, TodoListLogic>();
builder.Services.AddScoped<ITodoListRepository, TodoListRepository>();
builder.Services.AddTransient<ExceptionMiddleware>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(policyName);
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.Run();