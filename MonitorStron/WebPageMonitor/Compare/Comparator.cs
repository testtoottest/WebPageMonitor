using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WebPageMonitor.Models;

namespace Comparator
{
    class Comparator
    {
        // TODO: change arguments to Page and HtmlDocument. get the other document from a mock dbo and retrieve with mock fetcher
        public void Compare(HtmlDocument d1, HtmlDocument d2)
        {
            var compareResult = new Comparison(new Page()).Execute(d1.DocumentNode, d2.DocumentNode);
            // TODO: move to a mock notifier
            foreach (var d in compareResult)
                Console.WriteLine(d);
        }

        // basically should work, needs some tests
        class Comparison
        {

            public UsersInterestedInChangeGetter usersInterestedInChangeGetter { get; set; }

            private static string tnn = "#text";
            private Dictionary<PageUserMapping, Diff> result = new Dictionary<PageUserMapping, Diff>();

            public Comparison(Page page)
            {
                usersInterestedInChangeGetter = new UsersInterestedInChangeGetter(page);
            }

            public Dictionary<PageUserMapping, Diff> Execute(HtmlNode oldNode, HtmlNode newNode)
            {
                CompareNodes(oldNode, newNode);
                return result;
            }

            private void CompareNodes(HtmlNode oldNode, HtmlNode newNode)
            {
                if (oldNode.Name == tnn && newNode.Name == tnn && newNode.InnerText != oldNode.InnerText)
                    TextNodeChanged(newNode.ParentNode, oldNode.InnerText, newNode.InnerText);
                else if (oldNode.Name != newNode.Name)
                    NodeReplaced(oldNode, newNode);
                else
                {
                    int i;
                    for (i = 0; i < Math.Min(oldNode.ChildNodes.Count, newNode.ChildNodes.Count); i++)
                        CompareNodes(oldNode.ChildNodes[i], newNode.ChildNodes[i]);
                    foreach (var n in oldNode.ChildNodes.Skip(i))
                        NodeRemoved(n);
                    foreach (var n in newNode.ChildNodes.Skip(i))
                        NodeAdded(n);
                }

            }

            private delegate void NodeAnalyser(HtmlNode n);
            private void forEachChildNode(HtmlNode n, NodeAnalyser f)
            {
                foreach (var c in n.ChildNodes) f(c);
            }
            private void NodeAdded(HtmlNode n)
            {
                if (n.Name == tnn) ResolveNodeChange(n, "", n.InnerText);
                else forEachChildNode(n, NodeAdded);
            }
            private void NodeRemoved(HtmlNode n)
            {
                if (n.Name == tnn) ResolveNodeChange(n, n.InnerText, "");
                else forEachChildNode(n, NodeRemoved);
            }
            private void TextNodeChanged(HtmlNode parentNode, string oldContent, string newContent)
            {
                ResolveNodeChange(parentNode, oldContent, newContent);
            }
            private void NodeReplaced(HtmlNode oldNode, HtmlNode newNode)
            {
                NodeRemoved(oldNode);
                NodeAdded(newNode);
            }

            private void ResolveNodeChange(HtmlNode n, string oldContent, string newContent)
            {
                var pum = usersInterestedInChangeGetter.GetUsersInterestedInChange(n);
                // TODO: if pum is not empty, create Change and ChangeInfo for Node n
                foreach (var u in pum)
                {
                    Diff d;
                    if (!result.TryGetValue(u, out d)) d = new Diff(u);
                    // TODO: 
                    d.changes.Add(new ChangeContent(new Opinion() /* TODO: create and pass Opinion for change made before loop and u instead*/, oldContent, newContent));
                    result.Add(u, d);
                }
            }

            private void PrintHtmlTree(HtmlNode n, string indent = "")
            {
                Console.WriteLine(indent + n.Name);
                if (n.Name == "#text")
                    Console.WriteLine(indent + "  " + n.InnerText);
                foreach (var c in n.ChildNodes)
                    PrintHtmlTree(c, indent + "  ");
            }
        }
    }
}
