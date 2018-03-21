using System;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(".+\n");
            var document = new HtmlDocument();
            document.LoadHtml("<html><body id='body'></body></html>");
            
            foreach (Match item in regex.Matches(new StreamReader(args[0]).ReadToEnd()))
            {
                var value = item.Value.Replace("\n", string.Empty);
                document.GetElementbyId("body").InnerHtml += $"<a href='{value}'>{value}</a><br><br>";
            }
            document.Save(new StreamWriter(args[0].Replace(".txt", ".html")));
            System.Console.WriteLine("Done.");
        }
    }
}
