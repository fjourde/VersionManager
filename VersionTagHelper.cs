using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace VersionManager
{
	[HtmlTargetElement("website-version", TagStructure = TagStructure.WithoutEndTag)]
	public class VersionTagHelper : TagHelper
	{

		public string File { get; set; }

		public string DivClass { get; set; }

		public string UlClass { get; set; }

		public string LiClass { get; set; }

		public string DateClass { get; set; }

		public string VersionClass { get; set; }

		public string ValueClass { get; set; }


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			// Check parameters
			if (String.IsNullOrWhiteSpace(File) || !File.EndsWith(".json"))
			{
				File = "versions.json";
			}

			if (String.IsNullOrWhiteSpace(DateClass))
			{
				DateClass = "badge badge-secondary";
			}

			if (String.IsNullOrWhiteSpace(VersionClass))
			{
				VersionClass = "badge badge-primary ml-1";
			}

			if (String.IsNullOrWhiteSpace(DivClass))
			{
				DivClass = "";
			}

			if (String.IsNullOrWhiteSpace(UlClass))
			{
				UlClass = "";
			}

			if ( String.IsNullOrWhiteSpace(LiClass))
			{
				LiClass = "";
			}

			if(String.IsNullOrWhiteSpace(ValueClass))
			{
				ValueClass = "text-muted ml-1";
			}

			// Get File or default File (versions.json)
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, File);
			string json = System.IO.File.ReadAllText(path, System.Text.Encoding.ASCII);
			List<Version> versions = JsonConvert.DeserializeObject<List<Version>>(json);


			// Vrite Result in page
			StringBuilder s = new StringBuilder();
			foreach(Version version in versions)
			{
				s.Append("<div class=\"" + DivClass + "\">");
				s.Append("<span class=\""+ DateClass+"\">" + version.Date + "</span>");
				s.Append("<span class=\""+ VersionClass+"\">" + version.Id + "</span>");
				
				if (!String.IsNullOrWhiteSpace(version.Value))
				{
					s.Append("<span class=\"" + ValueClass + "\">" + version.Value+"</span>");
				}
				
				s.Append("<ul class=\"" + UlClass + "\">");
				foreach(var item in version.Items)
				{
					s.Append("<li class=\"" + LiClass + "\">" + @item + "</li>");
				}
				s.Append("</ul>");
				s.Append("</div>");
			}

			output.TagName = "";
			output.Content.SetHtmlContent(s.ToString());

		}
	}
}
