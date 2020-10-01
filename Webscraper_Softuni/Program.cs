using HtmlAgilityPack;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Webscraper_Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.marinetraffic.com/en/ais/details/ships/shipid:284423/mmsi:334024000/imo:9084255/vessel:INCHCAP";


            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream data = response.GetResponseStream();
            string html = String.Empty;
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            Console.WriteLine(html);




            //HtmlWeb web = new HtmlWeb();
            //var htmlDoc = web.Load(url);
            //var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");
            //Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);




            // Console.WriteLine(ReadData(url)); 
        }

        public static string ReadData(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            var html =  httpClient.GetStringAsync(url).GetAwaiter().GetResult();
            return html;
        }
    }
}
