using Core.UI.Extentions;
using Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Elements.Containers
{
    public abstract class BaseContainerWrapper
    {
        private readonly IWebElement currentContainer;
        private readonly IWebElement outerContainer;

        protected BaseContainerWrapper(By locatorBy)
        {
            CurrentElementLocator = locatorBy;
        }
        protected BaseContainerWrapper(IWebElement elementcontainer)
        {
            currentContainer = elementcontainer;
        }

        protected BaseContainerWrapper(IWebElement outerContainer, By locatorBy)
        {
            CurrentElementLocator = locatorBy;
            outerContainer = outerContainer;
        }
        protected By CurrentElementLocator { get; }

        protected IWebElement OuterContainer => outerContainer ?? DriverExtensions.GetElement(WebDriverConstants.DefaultContainerElement);

    }
}
