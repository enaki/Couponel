using System;

namespace Couponel.Business.Identities.Admins.Models
{
    public sealed class AdminModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
