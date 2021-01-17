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

            var options = new FirefoxOptions();
            options.AddArgument("--headless");
            //options.LogLevel = FirefoxDriverLogLevel.Info;
            options.LogLevel = FirefoxDriverLogLevel.Error;
            //options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;
            
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("webdriver.log.browser.ignore", true);
            profile.SetPreference("webdriver.log.driver.ignore", true);
            profile.SetPreference("webdriver.log.profiler.ignore", true);

            options.Profile = profile;
            
            FirefoxDriver driver;

            if (Environment.OSVersion.VersionString.ToLower().Contains("windows"))
                driver = new FirefoxDriver("D:\\Selenium\\Firefox\\", options);
                //driver = new FirefoxDriver(firefoxOptions);
            else
                driver = new FirefoxDriver(options);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var siteTestes = Environment.GetEnvironmentVariable("SiteTestes");
            driver.Navigate().GoToUrl("https://anp-imagemnasa.azurewebsites.net");

            //System.Threading.Thread.Sleep(3000);
            


            Console.WriteLine($"Resultado: {driver.Title}");

            //Close the browser
            driver.Quit();
        }
    }
}
