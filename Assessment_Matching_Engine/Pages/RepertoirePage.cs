using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Assessment_Matching_Engine.Pages
{
    public class RepertoirePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public RepertoirePage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement AdditionalFeatures => _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Additional Features')]")));
        private IWebElement ProductsSupportedLink => _wait.Until(d => d.FindElement(By.LinkText("Products Supported")));
        private IWebElement ProductsSectionHeading => _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'There are several types of Product Supported:')]")));

        public void ScrollToAdditionalFeatures()
        {
            new Actions(_driver).MoveToElement(AdditionalFeatures).Perform();
        }

        public void ClickProductsSupported()
        {
            ProductsSupportedLink.Click();
        }

        public IList<string> GetSupportedProductList()
        {
            var listItems = ProductsSectionHeading.FindElement(By.XPath("..")).FindElements(By.TagName("li"));
            return listItems.Select(li => li.Text.Trim()).Where(text => !string.IsNullOrEmpty(text)).ToList();
        }
    }
}
