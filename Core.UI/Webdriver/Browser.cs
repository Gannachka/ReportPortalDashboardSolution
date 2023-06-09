using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Core.UI.WebDriver.Interfaces;
using OpenQA.Selenium.Support.UI;
using Core.AppSettings;
using OpenQA.Selenium.Interactions;
using static Core.LoggerSerilog;
using Core.UI.Extentions;
using Core.UI.WebElements.Interfaces;

namespace Core.UI.WebDriver
{
    public class Browser : IBrowser
    {
        private readonly IWebDriver webDriver;
        private readonly int waitTimeInSeconds = ApplicationConfig.ExplicitTimeout;

        public Browser(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public T InvokeFunc<T>(Func<IWebDriver, T> func)
        {
            this.VerifyIsDisposed();

            return func != null ? func(this.webDriver) : default(T);
        }
        
        private void VerifyIsDisposed()
        {
            if (this.IsDisposed)
            {
                throw new InvalidOperationException("Browser is in disposed state");
            }
        }
        public string Url => webDriver.Url;
       
        public bool IsDisposed { get; private set; }
        public string Title => webDriver.Title;

        public WebDriverWait WebBrowserWait() => new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitTimeInSeconds));

        public string PageSource => webDriver.PageSource;

        public string CurrentWindowHandle => webDriver.CurrentWindowHandle;

        public void GoBack()
        {
            this.InovkeAction(wd => wd.Navigate().Back());
        }
        public T GoBack<T>() where T : ICreatablePageObject
        {
            this.GoBack();
            return DriverExtensions.CreatePageInstance<T>();
        }
        public void GoForward()
        {
            this.InovkeAction(wd => wd.Navigate().Forward());
        }
        public T GoForward<T>() where T : ICreatablePageObject
        {

            this.GoForward();
            return DriverExtensions.CreatePageInstance<T>();
        }
          
        public ReadOnlyCollection<string> WindowHandles => webDriver.WindowHandles;
        public void InovkeAction(Action<IWebDriver> action)
        {
            this.VerifyIsDisposed();
            action?.Invoke(this.webDriver);
        }
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