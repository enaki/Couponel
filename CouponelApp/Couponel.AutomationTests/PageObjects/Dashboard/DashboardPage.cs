using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Couponel.AutomationTests.PageObjects.Dashboard
{
    public class DashboardPage
    {
        public IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(10)));
        }

        [FindsBy(How = How.ClassName, Using = "flex-row-end")]
        public IWebElement UserMenu { get; set; }

        public void WaitForPageToLoad(string selector)
        {
            var wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(selector)));
        }
    }
}
