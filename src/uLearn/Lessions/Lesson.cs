﻿using System.Xml.Serialization;

namespace uLearn.Lessions
{
	[XmlRoot("Lesson", IsNullable = false, Namespace = "https://ulearn.azurewebsites.net/lesson")]
	public class Lesson
	{
		[XmlElement("title")]
		public string Title;

		[XmlElement("id")]
		public string Id;

		[XmlElement(typeof(YoutubeBlock))]
		[XmlElement(typeof(MdBlock))]
		[XmlElement(typeof(CodeBlock))]
		[XmlElement(typeof(TexBlock))]
		[XmlElement(typeof(ImageGaleryBlock))]
		[XmlElement(typeof(IncludeCodeBlock))]
		[XmlElement(typeof(IncludeMdBlock))]
		[XmlElement(typeof(IncludeImageGalleryBlock))]
		public SlideBlock[] Blocks;

		public Lesson()
		{
		}

		public Lesson(string title, string id, SlideBlock[] blocks)
		{
			Title = title;
			Id = id;
			Blocks = blocks;
		}
	}
}