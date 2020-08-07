using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Institutions;

namespace Couponel.IntegrationTests.Shared
{
    public static class UniversityModelFactory
    {
        public static University Default()
        {
            return new University("university", "university@yahoo.com", "0456324862");

        }
    }
}
