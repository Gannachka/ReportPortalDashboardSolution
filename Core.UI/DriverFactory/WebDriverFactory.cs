using Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Edge;

namespace Core.UI.DriverFactory
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browsers browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case Browsers.Chrome:
                    var chromeOption = new ChromeOptions();
                    //chromeOption.AddArgument("headless");
                    driver = new ChromeDriver(chromeOption);
                    break;
                case Browsers.FireFox:
                    var fireFoxOptions = new FirefoxOptions();
                    //fireFoxOptions.AddArgument("--headless");
                    driver = new FirefoxDriver(fireFoxOptions);
                    break;
                case Browsers.Edge:
                    var edgeOptions = new EdgeOptions();
                    //edgeOptions.AddArgument("headless");
                    driver = new EdgeDriver(edgeOptions);
                    break;
                default:
                    throw new PlatformNotSupportedException($"{browser} is not currently supported.");
            }

            return driver;
        }
    }
}
