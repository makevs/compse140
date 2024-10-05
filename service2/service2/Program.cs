using service2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.WebHost.UseUrls("http://*:8200");

var responseGenerator = new ResponseGenerator();

var app = builder.Build();

app.MapGet("/", () =>
{
    var response = responseGenerator.Response; // Get the JSON response
    return Results.Json(response); // Return as JSON
});

app.Run();
