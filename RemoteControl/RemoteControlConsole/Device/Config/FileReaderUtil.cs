using Core.Device;
using Newtonsoft.Json;
using System.Text;

namespace Core.Utility
{
    public static class ConfigFileName
    {
        public static readonly string Suffix = ".json";

        public static readonly Dictionary<Type, string> Mapper = new()
        {
            { typeof(TU7000_Spec), "TU7000_Spec" }
        };

        public static string GetFileName<T>()
        {
            return Mapper[typeof(T)] + Suffix;
        }
    }

    internal class FileReaderUtil
    {
        private static string GetJsonFilePath(string relativeFilePath)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string? projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.Parent?.FullName;
            return Path.Combine(projectDirectory ?? "", "ExternalData", relativeFilePath);
        }

        private static bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        private static byte[]? LoadFile(string absolutePath)
        {
            if (absolutePath == null || absolutePath.Length == 0)
                return null;
            if (File.Exists(absolutePath))
                return File.ReadAllBytes(absolutePath);
            return null;
        }

        private static T GetContent<T>(string dir)
        {
            byte[]? data = LoadFile(dir);
            if (data == null) throw new FileNotFoundException(dir);
            string json = Encoding.UTF8.GetString(data);

            T? content = JsonConvert.DeserializeObject<T>(json);
            if (content == null) throw new Exception();
            return content;
        }

        public static async Task<T> Read<T>(string filePath)
        {
            string dir = GetJsonFilePath(filePath);
            await Task.Delay(1);
            if (CheckFileExist(dir))
                return GetContent<T>(dir);

            throw new FileNotFoundException(dir);
        }
    }
}