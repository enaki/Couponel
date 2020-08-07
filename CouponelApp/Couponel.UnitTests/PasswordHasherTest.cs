using Couponel.Business.Authentications.Services.Implementations;
using Couponel.Business.Authentications.Services.Interfaces;
using Xunit;
using Xunit.Abstractions;

namespace Couponel.UnitTests
{
    public class PasswordHasherTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public PasswordHasherTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void HasherTest_01()
        {
            IPasswordHasher passHasherService = new PasswordHasher();

            var passHash = passHasherService.CreateHash("admin");

            Assert.True(passHasherService.Check(passHash, "admin"));
        }

        [Fact]
        public void DummyTest()
        {
            IPasswordHasher passHasherService = new PasswordHasher();


            var passwordToTest = "ion";
            var passHash = passHasherService.CreateHash(passwordToTest);
            _testOutputHelper.WriteLine($"{passwordToTest} -> {passHash}");

            Assert.True(true);
        }
    }
}
