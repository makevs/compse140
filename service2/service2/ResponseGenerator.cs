using System.Diagnostics;

namespace service2
{
    public class ResponseGenerator
    {
        public object Response => GenerateResponse();

        private object GenerateResponse()
        {
            string localIp = RunCommand("hostname", "-I").Trim();
            string processListRaw = RunCommand("ps", "-ax");
            var runningProcesses = processListRaw.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string diskSpaceRaw = RunCommand("df", "-h");
            var diskSpace = diskSpaceRaw.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string uptime = RunCommand("uptime", "-p").Trim();

            var response = new
            {
                LocalIP = localIp,
                RunningProcesses = runningProcesses,
                DiskSpace = diskSpace,
                Uptime = uptime
            };

            return response;
        }

        private string RunCommand(string command, string args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(startInfo))
            {
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                return result.Trim();
            }
        }
    }
}
