using Core.UI.WebDriverWrapper.Interfaces;
using Core.UI.WebElementWrapper.Interfaces;

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