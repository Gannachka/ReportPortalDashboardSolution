using Core.UI.Elements;
using Core.UI.Elements.Interfases;
using Core.UI.Extentions;
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

        public ILabel Logo => new Label(DriverExtensions.GetElement(LogoLocator));
    }
}
