using System.Diagnostics;
using System.IO;

namespace nardnob.AlgorithmComparison.Sorting.Files
{
    public static class FileHandler
    {
        public static bool OpenWithDefaultProgram(string filePath, bool waitForExit = false)
        {
            if (!File.Exists(filePath))
                return false;

            using Process? process = Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer",
                Arguments = $"{filePath}"
            });

            if (waitForExit)
            {
                process?.WaitForExit();
                return process?.ExitCode == 1;
            }

            return true;
        }
    }
}
