using Core.AppSettings;
using Core.UI.BrowserBuilder;
using Core.UI.WebDriver.Interfaces;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using Core;

namespace Tests.UI
{
    public class BaseUITest : BaseTest
    {

        protected IBrowser Browser;

        [SetUp]
        public void SetUp()
        {
            Browser = BrowserCreator.GetBrowser(ApplicationConfig.BrowserName);
            Browser.Manage().Window.Maximize();
            Browser.Navigate().GoToUrl(ApplicationConfig.URL);
            BrowserPool.RegisterAndMakeCurrentBrowser("Browser", Browser);
        }

        [TearDown]
        public void CloseBrowser()
        {
            BrowserCreator.ReleaseInstance();
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
