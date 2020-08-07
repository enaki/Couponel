using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Couponel.AutomationTests.PageObjects.Login
{
    public class LoginPage
    {
        public IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver,TimeSpan.FromSeconds(10)));
        }
        #region Login_section
            [FindsBy(How = How.CssSelector, Using = "[formcontrolname='username']")]
            public IWebElement TxtUsername { get; set; }

            [FindsBy(How = How.CssSelector, Using = "[formcontrolname='password']")]
            public IWebElement TxtPassword { get; set; }

            [FindsBy(How = How.CssSelector, Using = "[type='button']")]
            public IWebElement BtnLogin { get; set; }
            #endregion

            public void Login(string username, string password)
            {
                TxtUsername.SendKeys(username);
                TxtPassword.SendKeys(password);
                BtnLogin.Click();
            }

    }
}
