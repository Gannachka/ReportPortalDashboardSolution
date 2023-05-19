using Core.UI.BrowserBuilder;
using Core.UI.WebDriverWrapper;
using Core.UI.WebElementWrapper.Interfaces;
using OpenQA.Selenium;

namespace Core.UI.Extentions
{
    /// <summary>
    /// Driver extensions
    /// </summary>
    public static partial class DriverExtensions
    {
        public static T CreatePageInstance<T>(params object[] args) where T: ICreatablePageObject
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
        public static IWebElement GetElement(By elementBy)
        {
            return BrowserPool.CurrentBrowser.InvokeFunc(wd => wd.FindElement(elementBy));
        }

       
    }
}
