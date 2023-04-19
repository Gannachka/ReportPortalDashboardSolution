using Core.UI.WebDriverWrapper.Interfaces;
using Core.UI.WebElementWrapper;
using OpenQA.Selenium;


namespace PageObjects.Pages
{
    public class LoginPage :BasePage
    {
        private readonly By LogoLocator = By.ClassName("loginPage__logo--4NIFP");
        public LoginPage(IBrowser driver) : base(driver)
        {
            this.Driver = driver;
        }

        public IElement Logo => Driver.FindElement(LogoLocator);
    }
}
