
namespace CouponelServices.Business.Institutions.Address.Models
{
    public sealed class CreateAddressModel
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
    }
}
