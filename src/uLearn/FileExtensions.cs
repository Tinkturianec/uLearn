using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace uLearn
{
	public static class FileExtensions
	{
		public static FileInfo GetFile(this DirectoryInfo dir, string filename)
		{
			return new FileInfo(Path.Combine(dir.FullName, filename));
		}

		public static DirectoryInfo GetSubdir(this DirectoryInfo dir, string name)
		{
			return new DirectoryInfo(Path.Combine(dir.FullName, name));
		}

		public static string ContentAsUtf8(this FileInfo file)
		{
			return File.ReadAllText(file.FullName, Encoding.UTF8);
		}

		public static T DeserializeXml<T>(this FileInfo file)
		{
			var serializer = new XmlSerializer(typeof (T));
			using(var stream = file.OpenRead())
				return (T) serializer.Deserialize(stream);
		}
	}
}