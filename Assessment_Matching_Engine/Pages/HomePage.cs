using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Assessment_Matching_Engine.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement ModulesMenu => _wait.Until(d => d.FindElement(By.LinkText("Modules")));
        private IWebElement RepertoireLink => _wait.Until(d => d.FindElement(By.LinkText("Repertoire Management Module")));

        public void NavigateTo()
        {
            _driver.Navigate().GoToUrl("https://www.matchingengine.com/");
        }

        public void ExpandModulesMenu()
        {
            ModulesMenu.Click();
        }

        public void ClickRepertoireModule()
        {
            RepertoireLink.Click();
        }
    }
}