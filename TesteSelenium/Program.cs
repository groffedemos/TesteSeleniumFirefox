using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace TesteSelenium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando o uso de Selenium..");

            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");

            FirefoxDriver driver;

            //if (Environment.OSVersion.VersionString.ToLower().Contains("windows"))
            //    driver = new FirefoxDriver("D:\\Selenium\\Firefox\\", firefoxOptions);
                //driver = new FirefoxDriver(firefoxOptions);
            //else
            //    driver = new FirefoxDriver(firefoxOptions);


            var siteTestes = Environment.GetEnvironmentVariable("SiteTestes");
            driver.Navigate().GoToUrl("https://anp-imagemnasa.azurewebsites.net/");

            System.Threading.Thread.Sleep(3000);

            Console.WriteLine($"Resultado: {driver.Title}");

            //Close the browser
            driver.Quit();
        }
    }
}
