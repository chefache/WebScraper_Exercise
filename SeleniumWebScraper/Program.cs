using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebScraper
{
    class Program
    {
        private static IWebDriver driver;
        static void Main(string[] args)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.marinetraffic.com/en/ais/details/ships/shipid:994899/mmsi:311000306/imo:9696773/vessel:ALFA_BALTICA");

            var pageHtml = driver.FindElement(By.XPath(""));

            //HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            //document.LoadHtml(pageHtml);
            //document.GetElementbyId("Latitude");
            //Console.WriteLine(document.Text);
        }
    }
}
