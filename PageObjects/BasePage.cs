using Core.UI.WebDriverWrapper.Interfaces;

namespace PageObjects
{
    public class BasePage
    {
        protected IBrowser Driver;

        protected BasePage(IBrowser driver)
        {
            Driver = driver;
        }
    }
}