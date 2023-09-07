using System;

namespace HtmlWriter
{
    class Program
    {
        static void Main()
        {
            var rootNode = GetRootNode();
            int indent = 0;

            WriteHtml(rootNode, indent);
        }

        static void WriteHtml(HtmlNode rootNode, int indent)
        {

        }

        private static HtmlNode GetRootNode()
        {
            HtmlNode root = new HtmlNode("html");

            HtmlNode head = new HtmlNode("head");
            root.ChildNodes.Add(head);

            HtmlNode title = new HtmlNode("title");
            head.ChildNodes.Add(title);

            HtmlNode body = new HtmlNode("body");
            root.ChildNodes.Add(body);
            body.Attributes.Add(new HtmlAttribute("class", "container"));

            HtmlNode div1 = new HtmlNode("div");
            body.ChildNodes.Add(div1);
            div1.Attributes.Add(new HtmlAttribute("class", "navbar-container"));
            div1.Attributes.Add(new HtmlAttribute("id", "navbar"));

            HtmlNode div2 = new HtmlNode("div");
            body.ChildNodes.Add(div2);
            div2.Attributes.Add(new HtmlAttribute("class", "main-container"));
            div2.Attributes.Add(new HtmlAttribute("id", "main-container"));

            return root;
        }
    }
}
