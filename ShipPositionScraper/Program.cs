using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ShipPositionScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter IMO code: ");
            int imoCode = 9486403;
            var pageHttp = GetHttp(imoCode);
            Console.WriteLine(pageHttp);


            WebClient webClient = new WebClient();
            string htmlCode = webClient.DownloadString("https://www.marinetraffic.com/en/ais/details/ships/shipid:994899/mmsi:311000306/imo:9696773/vessel:ALFA_BALTICA");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(htmlCode);
            HtmlNode node = document.DocumentNode.SelectSingleNode("//*[@id=\"vesselDetails_latestPositionSection\"]/div[2]/div/div/div/div/div[1]/p[5]/b/a");

            Console.WriteLine(node.InnerText);
        }

        private static string GetHttp(int imoCode)
        {
            string address = $"https://www.marinetraffic.com/en/ais/details/ships/shipid:/mmsi:/imo:{imoCode}/vessel:";
            HttpClient httpClient = new HttpClient();

            var addressAsync = httpClient.GetAsync(address);
            var httpResponse = addressAsync.GetAwaiter().GetResult();
            var responseSplited = httpResponse.ToString().Split("\r\n");
            string rawWebAddress = responseSplited[7];

            return rawWebAddress.Substring(12, rawWebAddress.Length - 12);
        }

        public static string GetHtml(string pageUrl)
        {
            HttpClient client = new HttpClient();
            var pageResponse = client.GetAsync(pageUrl).GetAwaiter().GetResult();
            var byteContent = pageResponse.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            var html = Encoding.GetEncoding("windows-1251").GetString(byteContent);
            return html;
        }
    }
}
