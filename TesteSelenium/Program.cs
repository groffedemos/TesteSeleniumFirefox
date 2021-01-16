﻿using System;
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

            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.LogLevel = ChromeDriverLogLevel.Info;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss;

            ChromeDriver driver;

            if (Environment.OSVersion.VersionString.ToLower().Contains("windows"))
                driver = new ChromeDriver("D:\\Selenium\\Firefox\\", options);
                //driver = new FirefoxDriver(firefoxOptions);
            else
                driver = new ChromeDriver(options);

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var siteTestes = Environment.GetEnvironmentVariable("SiteTestes");
            driver.Navigate().GoToUrl("https://github.com");

            System.Threading.Thread.Sleep(3000);
            


            Console.WriteLine($"Resultado: {driver.Title}");

            //Close the browser
            driver.Quit();
        }
    }
}
