using Core.UI.WebDriverWrapper;
using Core.UI.WebElementWrapper.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static Core.Log;

namespace Core.UI.WebElementWrapper
{
    public class BaseElement : IBaseElement
    {
        protected IWebElement WebElement;
        protected By By;
        private readonly Browser browser;

        public BaseElement(IWebElement element, By by)
        {
            WebElement = element;
            By = by;
        }

        public BaseElement(IWebElement element)
        {
            WebElement = element;
          
        }

        public BaseElement(By by)
        {
            By = by;
        }

        public string TagName => WebElement.TagName;

        public string Text => WebElement.Text;

        public bool Enabled => WebElement.Enabled;

        public bool Selected => WebElement.Selected;

        public Point Location => WebElement.Location;

        public Size Size => WebElement.Size;

        public bool Displayed => WebElement.Displayed;

        public void Clear()
        {
            WebElement.Clear();
        }

        public void Click()
        {
            Information("The element was clicked");
            WebElement.Click();
        }

        public IBaseElement FindElement(By by)
        {

                var wait = browser.WebBrowserWait();
                var webElement = wait.Until(drv => drv.FindElement(by));

                return new BaseElement(webElement, by);
           
        }

        public IReadOnlyCollection<IBaseElement> FindElements(By by)
        {
            var wait = browser.WebBrowserWait();
            wait.Until(drv => drv.FindElements(by).Count > 0);
            IReadOnlyCollection<IWebElement> webELements = WebElement.FindElements(by);
            List<IBaseElement> elements = new List<IBaseElement>();

            foreach (IWebElement element in webELements)
            {
                 elements.Add(new BaseElement(element, by));
            }

            return elements.ToList();
            
        }

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return WebElement.GetCssValue(propertyName);
        }

        public void SendKeys(string text)
        {
            WebElement.SendKeys(text);
            Information($"Text '{text}' was entered");
        }

        public void Submit()
        {
            WebElement.Submit();
        }

        public void MouseOver()
        {
            browser.Action().MoveToElement(WebElement);
        }
    }
}