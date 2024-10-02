using System;
using System.Diagnostics;

namespace service2;
internal class TestPs
{
    public static void Exec()
    {
        // Run the "ps -ax" command
        RunCommand("ps", "-ax");
        
        // Run the "df" command
        RunCommand("df", "");
    }

    static void RunCommand(string command, string args)
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
            Console.WriteLine(result);
        }
    }
}