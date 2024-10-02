using service2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var response = new ResponseGenerator();

var app = builder.Build();

app.MapGet("/", () =>
{
    response.GenerateResponse();
    
    Console.WriteLine("Running ps execution");
    TestPs.Exec();
    
    return response.Response;
});

app.Run();