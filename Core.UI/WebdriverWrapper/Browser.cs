using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Core.UI.WebDriverWrapper.Interfaces;
using OpenQA.Selenium.Support.UI;
using Core.UI.WebElementWrapper;
using Core.AppSettings;
using OpenQA.Selenium.Interactions;
using static Core.Log;

namespace Core.UI.WebDriverWrapper
{
    public class Browser : IBrowser
    {
        private readonly IWebDriver webDriver;
        private readonly int waitTimeInSeconds = ApplicationConfig.ExplicitTimeout;

        public Browser(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public Actions actions => new Actions(webDriver);
        public IElement FindElement(By by)
        {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
                var webElement = wait.Until(drv => drv.FindElement(by));

                Information("The element {0} was found successfully", by);

                return new Element(webElement, by);
                     
        }

        public IReadOnlyCollection<IElement> FindElements(By by)
        {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));
                wait.Until(drv => drv.FindElements(by).Count > 0);
                var webElements = webDriver.FindElements(by);
                var elements = new List<IElement>();

                foreach (IWebElement webElement in webElements)
                {
                    elements.Add(new Element(webElement, by));
                }

                return elements.ToList();                            
        }

        public string Url
        {
            get => webDriver.Url;
            set => webDriver.Url = value;
        }

        public string Title => webDriver.Title;

        public WebDriverWait WebBrowserWait() => new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));

        public string PageSource => webDriver.PageSource;

        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;

        public IOptions Manage()
        {
            return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return webDriver.SwitchTo();
        }

        public Screenshot TakeScreenshot()
        {
            Debug("Take Screenshot");
            return ((ITakesScreenshot)webDriver).GetScreenshot();
        }

        public void Quit()
        {
            webDriver.Quit();
        }

        public void Close()
        {
            webDriver.Close();
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }

        public Actions Action() => new(webDriver);
    }
}