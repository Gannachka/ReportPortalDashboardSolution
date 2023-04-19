using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Core.UI.WebElementWrapper;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace Core.UI.WebDriverWrapper.Interfaces
{
    public interface IBrowser : IDisposable
    {
        string Url { get; set; }

        string Title { get; }

        string PageSource { get; }

        string CurrentWindowHandle { get; }

        ReadOnlyCollection<string> WindowHandles { get; }

        WebDriverWait WebBrowserWait();

        void Close();

        IOptions Manage();

        INavigation Navigate();

        void Quit();

        ITargetLocator SwitchTo();

        IElement FindElement(By by);

        IReadOnlyCollection<IElement> FindElements(By by);

        Screenshot TakeScreenshot();

        Actions Action();
    }
}
