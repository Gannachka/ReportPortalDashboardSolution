using Core.UI.WebDriver.Interfaces;
using Core.UI.WebElements.Interfaces;

namespace PageObjects
{
    public class BasePage: ICreatablePageObject
    {
        protected IBrowser Driver;

        protected BasePage(IBrowser driver)
        {
          
        }
    }
}