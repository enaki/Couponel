namespace Couponel.Entities.Identities.UserTypes
{
    public sealed class Offerer : Person
    {
        public Offerer(string firstName, string lastName, string email, string phoneNumber) 
            : base(firstName, lastName, email, phoneNumber)
        {
        }
    }
}
