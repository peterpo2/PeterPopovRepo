using System;
using System.Linq;

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
            string indentation = new string(' ', indent * 2);
            if (!rootNode.ChildNodes.Any())
            {
                // no childnodes -> print on the same line
                Console.WriteLine(indentation + StringifyOpeningTag(rootNode) + StringifyClosingTag(rootNode));
            }
            else
            {
                Console.WriteLine(indentation + StringifyOpeningTag(rootNode));

                foreach (var childNode in rootNode.ChildNodes)
                {
                    WriteHtml(childNode, indent + 2);
                }

                // print the closing tag after we are done with all child nodes
                Console.WriteLine(indentation + StringifyClosingTag(rootNode));
            }
        }

        static string StringifyOpeningTag(HtmlNode node)
        {
            string attrsToString = node.Attributes.Any()
                ? " " + string.Join(" ", node.Attributes.Select(a => $"{a.Name}=\"{a.Value}\""))
                : string.Empty;

            return $"<{node.Name}{attrsToString}>";
        }

        static string StringifyClosingTag(HtmlNode node)
        {
            return $"</{node.Name}>";
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
