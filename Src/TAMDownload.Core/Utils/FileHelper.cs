using System.Text.Json;
using System.Text.RegularExpressions;

namespace TAMDownload.Core.Utils
{
    public static class FileHelper
    {
        private const string MetadataFile = "metadata.json";
        private const string MetadataBackupFile = "metadata.json.bak";

        public static T LoadMetadata<T>() where T : new()
        {
            if (!File.Exists(MetadataFile))
                return new T();

            var json = File.ReadAllText(MetadataFile);
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }

        public static void SaveMetadata<T>(T metadata)
        {
            if (File.Exists(MetadataBackupFile))
                File.Delete(MetadataBackupFile);

            if (File.Exists(MetadataFile))
                File.Move(MetadataFile, MetadataBackupFile);

            var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(MetadataFile, json);
        }

        public static string SafePath(string path)
        {
            var invalids = Path.GetInvalidFileNameChars();
            return string.Join("_", path.Split(invalids, StringSplitOptions.RemoveEmptyEntries));
        }

        public static string GetFileExtension(string url)
        {
            var formatMatch = Regex.Match(url, @"format=(\w+)&");
            if (formatMatch.Success)
                return formatMatch.Groups[1].Value;

            return url.Split('.').Last().Split('?').First();
        }

        public static string RemoveInvalidPathChars(string path)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            string pattern = "[" + Regex.Escape(new string(invalidChars)) + "]";
            return Regex.Replace(path, pattern, string.Empty);
        }
    }
}
