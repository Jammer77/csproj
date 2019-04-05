using System.Text;

namespace prj2json
{
    public static class BashHelper
    {
        public static string CreateBuildCommand(string projectName, string configuration)
        {
            return $"msbuild {projectName} / p:Configuration = {configuration}";
        }

        public static string CreateRunCommand(string path)
        {
            return $"mono {path}";
        }

        public static string CreateFileName(string projectName, string configuration, bool needRun)
        {
            var fileNameBuilder = new StringBuilder();

            return fileNameBuilder.ToString();
        }

        public static string MakeFileExecutable(string path)
        {
            throw new System.Exception();
        }
    }
}