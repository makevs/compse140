using service2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

ResponseGenerator response = new ResponseGenerator();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    response.GenerateResponse();
    
    return response.Response;
});

app.Run();