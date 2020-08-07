using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Entities.Institutions;

namespace Couponel.IntegrationTests.Shared
{
    public static class FacultyModelFactory
    {
        public static Faculty Default()
        {
            return new Faculty("facultate", "facultate@yahoo.com", "0745624578");
        }
    }
}
