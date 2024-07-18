using MobilePhoneWebApp.DataAccess.Entity;

namespace MobilePhoneWebApp.BusinessLogic.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int customerId { get; set; }
        public Customer ?customer { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
