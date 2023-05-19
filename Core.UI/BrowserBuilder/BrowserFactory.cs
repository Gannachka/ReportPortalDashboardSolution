using Core.Enums;
using Core.UI.DriverFactory;
using Core.UI.WebDriverWrapper;
using Core.UI.WebDriverWrapper.Interfaces;
using OpenQA.Selenium;

namespace Core.UI.BrowserBuilder
{
    public static class BrowserFactory
    {
        public static IBrowser Create(Browsers browserName)
        {
            IWebDriver driver = WebDriverFactory.CreateWebDriver(browserName);

            return new Browser(driver);
        }
    }
}
