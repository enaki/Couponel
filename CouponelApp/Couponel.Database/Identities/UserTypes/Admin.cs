namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Admin : Person
    {
        public Admin(string firstName, string lastName, string email, string phoneNumber)
            : base(firstName, lastName, email, phoneNumber)
        {
        }
    }
}
