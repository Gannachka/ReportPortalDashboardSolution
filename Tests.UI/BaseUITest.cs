using NUnit.Framework;
using Core;
using Core.AppSettings;
using Core.UI.WebDriverWrapper.Interfaces;
using Core.UI.BrowserBuilder;
using NUnit.Framework.Interfaces;
using TestContext = NUnit.Framework.TestContext;

namespace Tests.UI
{
    public class BaseUITest : BaseTest
    {
        protected IBrowser Browser;

        [SetUp]
        public void SetUp()
        {
            Browser = BrowserSingleton.GetBrowser(ApplicationConfig.BrowserName);
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl(ApplicationConfig.URL);
        }

        [TearDown]
        public void CloseBrowser()
        {
            BrowserSingleton.ReleaseInstance();
            SaveScreenshot();
            Browser.Close();
            Browser.Quit();
        }
        public void SaveScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = Browser.TakeScreenshot();
                ReportPortal.Shared.Context.Current.Log.Info(TestContext.CurrentContext.Test.Name, "screenshot/png", screenshot.AsByteArray);
            }
        }
    }
}
