using Couponel.Entities.Institutions;
using Couponel.Entities.ValueObjects;

namespace Couponel.IntegrationTests.Shared
{
    public static class InstitutionsModelFactory
    {
        public static Address Address()
        {
            return new Address("Romania", "Iasi", "Bucuriei", "42");
        }
        public static Faculty Faculty()
        {
            return new Faculty("facultate", "facultate@yahoo.com", "0745624578");
        }

        public static University University()
        {
            return new University("university", "university@yahoo.com", "0456324862");

        }
    }
}
