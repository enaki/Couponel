using System;

namespace Couponel.Business.Identities.Offerors.Models
{
    public sealed class OffererModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
