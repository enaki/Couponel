using System;
using System.Collections.Generic;
using System.Text;

namespace Couponel.Business.Authentications.Services.Interfaces
{
    public interface IPasswordHasher
    {
        string CreateHash(string password);
        bool Check(string hash, string password);
    }
}
