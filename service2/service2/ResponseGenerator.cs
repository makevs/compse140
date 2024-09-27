namespace service2;

public class ResponseGenerator
{
    public string Response => _response;
    private string? _response = "";

    public void GenerateResponse()
    {
        string pid = System.Environment.ProcessId.ToString();
        _response = $"Service 2: {pid}";
    }
}