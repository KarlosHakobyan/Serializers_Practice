using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Serealisers.Helpers
{
    public static class XmlHelper
    {
        private static readonly XmlWriterSettings DefaultSettings = new()
        {
            Indent = true,
            IndentChars = "    ",
            Async = true,
            CheckCharacters = false
        };

        public static string Serialize<T>(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var serializer = new XmlSerializer(typeof(T));
            using var stringWriter = new StringWriter();

            using (var xmlWriter = XmlWriter.Create(stringWriter, DefaultSettings))
            {
                serializer.Serialize(xmlWriter, data);
            }

            return stringWriter.ToString();
        }

        public static T? Deserialize<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml)) return default;

            var serializer = new XmlSerializer(typeof(T));
            using var stringReader = new StringReader(xml);

            return (T?)serializer.Deserialize(stringReader);
        }

        public static void SaveToFile<T>(string path, T data)
        {
            string xml = Serialize(data);
            File.WriteAllText(path, xml);
        }

        public static T? LoadFromFile<T>(string path)
        {
            if (!File.Exists(path)) return default;

            string xml = File.ReadAllText(path);
            return Deserialize<T>(xml);
        }

        public static async Task SaveToFileAsync<T>(string path, T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var serializer = new XmlSerializer(typeof(T));

            await using var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true);
            await using var xmlWriter = XmlWriter.Create(fileStream, DefaultSettings);

            serializer.Serialize(xmlWriter, data);
        }

        public static async Task<T?> LoadFromFileAsync<T>(string path)
        {
            if (!File.Exists(path)) return default;

            var serializer = new XmlSerializer(typeof(T));

            await using var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
            return (T?)serializer.Deserialize(fileStream);
        }
    }
}