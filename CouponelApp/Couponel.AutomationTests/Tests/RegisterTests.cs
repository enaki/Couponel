using System;
using System.Collections.Generic;
using System.Text;
using Couponel.AutomationTests.Helpers;
using Couponel.AutomationTests.PageObjects.Dashboard;
using Couponel.AutomationTests.PageObjects.Login;
using Couponel.AutomationTests.PageObjects.Register;
using Xunit;

namespace Couponel.AutomationTests.Tests
{
    [Collection("Sequential")]
    public class RegisterTests:Browser, IDisposable
    {
        public LoginPage loginPage;
        public RegisterPage registerPage;
        public DashboardPage dashboardPage;
        public RegisterTests()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            registerPage = new RegisterPage(Driver);
        }

       
        [Fact]
        public void Register_With_Invalid_Email()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user);
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.BtnRegister.Click();
            Assert.True(registerPage.EmailInvalidCred.Displayed);
        }

        [Fact]
        public void Register_With_Invalid_Credentials()
        {
            var user = Utils.GetRandomString(3);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user);
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.BtnRegister.Click();
            Assert.True(registerPage.EmailInvalidCred.Displayed);
        }
        [Fact]
        public void Register_With_Valid_Credentials()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user + "@gmail.com");
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.BtnRegister.Click();
            loginPage = new LoginPage(Driver);
            loginPage.WaitForPageToLoad("[class='login-label']");
            Assert.True(loginPage.LabelLogin.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
