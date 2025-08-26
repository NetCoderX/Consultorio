using Consultorio.Persistence;
using Consultorio.Application;
using Consultorio.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddApplication()
                .AddPersistence(builder.Configuration);
var app = builder.Build();

app.UseManejadorEcepciones();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
