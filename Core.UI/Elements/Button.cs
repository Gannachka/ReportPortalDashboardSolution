using Core.UI.WebElements;
using static Core.LoggerSerilog;
using OpenQA.Selenium;
using Core.UI.Extentions;
using Core.UI.Elements.Interfases;
using Core.UI.WebElements.Interfaces;

namespace Core.UI.Elements
{
    public class Button: BaseElement, IButton
    {
        public Button(IWebElement element, By by) : base(element, by)
        {
        }

        public Button(By by) : base(by)
        {

        }
        /// <summary>
        /// The Click
        /// </summary>
        public virtual void Click()
        {
            string buttonName = this.Text;
            this.Click();
            Information("Click button:", buttonName);
        }

        /// <summary>
        /// The Click
        /// </summary>
        /// <typeparam name="TWebObject">
        /// The desired type of page object to be created
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICreatablePageObject"/>
        /// </returns>
        public TWebObject Click<TWebObject>()
            where TWebObject : ICreatablePageObject
        {
            this.Click();
            return DriverExtensions.CreatePageInstance<TWebObject>();
        }
    }
}
