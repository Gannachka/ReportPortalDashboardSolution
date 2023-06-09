using Core.UI.Elements.Interfases;
using Core.UI.WebElements;
using OpenQA.Selenium;

namespace Core.UI.Elements
{
    public class Label: BaseElement, ILabel
    {
        public Label(IWebElement element, By by) : base(element, by)
        {
        }
        public Label(IWebElement element) : base(element)
        {
        }
        public Label(By by) : base(by)
        {

        }

        /// <summary>
        /// Gets the hidden text.
        /// </summary>
        public string HiddenText => this.HiddenText;
    }
}
