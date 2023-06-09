using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Core.UI.WebElements;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using Core.UI.WebElements.Interfaces;

namespace Core.UI.WebDriver.Interfaces
{
    public interface IBrowser : IDisposable
    {
        string Url { get; }

        string Title { get; }

        string PageSource { get; }

        string CurrentWindowHandle { get; }

        ReadOnlyCollection<string> WindowHandles { get; }

        WebDriverWait WebBrowserWait();

        void Close();

        IOptions Manage();
        T InvokeFunc<T>(Func<IWebDriver, T> func);
        INavigation Navigate();
        bool IsDisposed { get; }
        void Quit();
        void GoBack();
        T GoBack<T>() where T: ICreatablePageObject;
        void GoForward();
        T GoForward<T>() where T : ICreatablePageObject;
        ITargetLocator SwitchTo();

        Screenshot TakeScreenshot();

        Actions Action();
    }
}
