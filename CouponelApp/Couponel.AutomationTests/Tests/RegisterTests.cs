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
        public RegisterPage registerPage;
        public DashboardPage dashboardPage;
        public RegisterTests()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            registerPage = new RegisterPage(Driver);
        }

        [Fact]
        public void Register_Student_With_Valid_Credentials()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user + "@gmail.com");
            registerPage.DropDownRole.Click();
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.ValueStudent.Click();
            registerPage.BtnRegister.Click();
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='flex-row-end']");
            Assert.True(dashboardPage.UserMenu.Displayed);
        }
        [Fact]
        public void Register_Student_With_Invalid_Email()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user);
            registerPage.DropDownRole.Click();
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.ValueStudent.Click();
            registerPage.BtnRegister.Click();
            Assert.True(registerPage.EmailInvalidCred.Displayed);
        }

        [Fact]
        public void Register_Student_With_Invalid_Email_Bug()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user+"@gmai");
            registerPage.DropDownRole.Click();
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.ValueStudent.Click();
            registerPage.BtnRegister.Click();
            Assert.True(registerPage.EmailInvalidCred.Displayed);
        }
        [Fact]
        public void Register_Student_With_Invalid_Credentials()
        {
            var user = Utils.GetRandomString(3);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user);
            registerPage.DropDownRole.Click();
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.ValueStudent.Click();
            registerPage.BtnRegister.Click();
            Assert.True(registerPage.EmailInvalidCred.Displayed);
        }
        [Fact]
        public void Register_Offerer_With_Valid_Credentials()
        {
            var user = Utils.GetRandomString(6);
            registerPage.CheckboxRegister.Click();
            registerPage.TxtUsername.SendKeys(user);
            registerPage.TxtFirstName.SendKeys(user);
            registerPage.TxtLastName.SendKeys(user);
            registerPage.TxtPassword.SendKeys(user);
            registerPage.TxtEmail.SendKeys(user + "@gmail.com");
            registerPage.DropDownRole.Click();
            registerPage.TxtPhoneNumber.SendKeys(Utils.GetRandomPhoneNumber(10));
            registerPage.ValueStudent.Click();
            registerPage.BtnRegister.Click();
            dashboardPage = new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='flex-row-end']");
            Assert.True(dashboardPage.UserMenu.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
