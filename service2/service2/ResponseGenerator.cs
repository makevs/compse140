using System.Diagnostics;
using System.Net;

namespace service2;

public class ResponseGenerator
{
    public string Response => _response;
    private string _response = "";

    public void GenerateResponse()
    {
        string localIp = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault()?.ToString() ?? "N/A";
        List<string> runningProcesses = Process.GetProcesses().Select(p => p.ProcessName).ToList();
        double? freeSpace = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady)?.AvailableFreeSpace;
        string spaceString = freeSpace.HasValue ? $"{freeSpace / 1024 / 1024 / 1024:F2} GB" : "N/A";
        
        string uptime = TimeSpan.FromMilliseconds(Environment.TickCount64).ToString();
        
        _response = $"Service 2\n" +
                    $"\tLocal IP: {localIp}\n" +
                    $"\tRunning processes: {string.Join(", ", runningProcesses)}\n" +
                    $"\tFree disk space: {spaceString}\n" +
                    $"\tUptime: {uptime}";
    }
}