using System.IO;

namespace TerraGen
{
    public static class ApplicationInfo
    {
        public const string LOCAL_HOME_DIR = ".terraform";

        public static string Name { get; } = "TerraGen";

        public static string GetWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
