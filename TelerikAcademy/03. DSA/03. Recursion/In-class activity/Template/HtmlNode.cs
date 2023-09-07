using System.Collections.Generic;

namespace HtmlWriter
{
	public class HtmlNode
	{
		public HtmlNode(string name)
		{
			this.Name = name;
			this.Attributes = new List<HtmlAttribute>();
			this.ChildNodes = new List<HtmlNode>();
		}
		public string Name { get; set; }

		public List<HtmlAttribute> Attributes { get; set; }

		public List<HtmlNode> ChildNodes { get; set; }
	}
}
