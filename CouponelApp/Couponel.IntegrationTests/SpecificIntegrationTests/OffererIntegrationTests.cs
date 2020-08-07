using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Couponel.IntegrationTests.SpecificIntegrationTests
{
    public class OffererIntegrationTests: IntegrationTests
    {
        public override async Task InitializeAsync()
        {
            await ExecuteDatabaseAction(async (couponelContext) => await CleanupDatabase(couponelContext));
            (AuthenticatedUserId, UserAuthenticationToken) = await SetAuthenticationToken(UserRole.Offerer);
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserAuthenticationToken);
        }
    }
}
