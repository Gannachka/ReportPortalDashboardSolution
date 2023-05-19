using OpenQA.Selenium;
using System.Drawing;

namespace Core.UI.WebElementWrapper.Interfaces
{
    public interface IBaseElement
    {
        string TagName { get; }

        string Text { get; }

        bool Enabled { get; }

        bool Selected { get; }

        Point Location { get; }

        Size Size { get; }

        bool Displayed { get; }

        void Clear();

        void Click();

        string GetAttribute(string attributeName);

        string GetCssValue(string propertyName);

        //string GetProperty(string propertyName);

        void SendKeys(string text);
        void Submit();

        void MouseOver();

        IBaseElement FindElement(By by);

        IReadOnlyCollection<IBaseElement> FindElements(By by);
    }
}
