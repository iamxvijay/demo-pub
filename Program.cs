using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure file-based logging
builder.Logging.AddFile("Logs/app-{Date}.txt");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirportRoutingAPI v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the root path "/"
    });

    // Redirect "/swagger" to "/"
    app.MapGet("/swagger", context =>
    {
        context.Response.Redirect("/", permanent: false);
        return Task.CompletedTask;
    });

    // Redirect "/swagger/index.html" to "/"
    app.MapGet("/swagger/index.html", context =>
    {
        context.Response.Redirect("/", permanent: false);
        return Task.CompletedTask;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
