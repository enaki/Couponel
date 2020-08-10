using System;
using Couponel.AutomationTests.Helpers;
using Couponel.AutomationTests.PageObjects.Dashboard;
using Couponel.AutomationTests.PageObjects.Login;
using Xunit;

namespace Couponel.AutomationTests.Tests
{
    [Collection("Sequential")]
    public class LoginTests: Browser, IDisposable
    {
        public LoginPage loginPage;
        public DashboardPage dashboardPage;
        public LoginTests()
        {
            Driver.Navigate().GoToUrl("http://localhost:4200/authentication");
            loginPage=new LoginPage(Driver);
        }

        [Fact]
        public void Login_With_Valid_Credentials()
        {
            loginPage.Login("mishu","mishu");
            dashboardPage=new DashboardPage(Driver);
            dashboardPage.WaitForPageToLoad("[class='flex-row-end']");
            Assert.True(dashboardPage.UserMenu.Displayed);
        }
        public void Dispose()
        {
            CloseBrowser();
        }
    }
}
