using System;
using System.Collections.Generic;
using System.Text;
using Couponel.AutomationTests.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Couponel.AutomationTests.PageObjects.Register
{
    public class RegisterPage:BasePage
    {
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(this.driver, TimeSpan.FromSeconds(20)));
        }

        #region Register section

        [FindsBy(How=How.CssSelector, Using="[type='checkbox']")]
        public IWebElement CheckboxRegister { get; set; }

        [FindsBy(How = How.ClassName, Using = "alert")]
        public IWebElement EmailInvalidCred { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='username']")]
        public IWebElement TxtUsername { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='firstName']")]
        public IWebElement TxtFirstName { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='lastName']")]
        public IWebElement TxtLastName { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='email']")]
        public IWebElement TxtEmail { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='password']")]
        public IWebElement TxtPassword { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[formcontrolname='phoneNumber']")]
        public IWebElement TxtPhoneNumber { get; set; }
        [FindsBy(How = How.CssSelector, Using = "[type='button']")]
        public IWebElement BtnRegister { get; set; }
        

        #endregion

    }
}
