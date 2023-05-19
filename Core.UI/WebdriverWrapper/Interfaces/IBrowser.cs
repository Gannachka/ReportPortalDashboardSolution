using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using Core.UI.WebElementWrapper;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;
using Core.UI.WebElementWrapper.Interfaces;

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
