using Core.AppSettings;
using Core.UI.BrowserBuilder;
using Core.UI.WebDriverWrapper.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TestContext = NUnit.Framework.TestContext;

namespace Core.UI.Tests
{
    public class BaseWebUITest : BaseTest 
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
