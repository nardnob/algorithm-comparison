using System.Diagnostics;
using System.IO;

namespace nardnob.AlgorithmComparison.Sorting.Files
{
    public static class FileHandler
    {
        public static bool OpenWithDefaultProgram(string path)
        {
            if (!File.Exists(path))
                return false;

            using Process? process = Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer",
                Arguments = $"{path}"
            });

            process?.WaitForExit();

            return process?.ExitCode == 1;
        }
    }
}
