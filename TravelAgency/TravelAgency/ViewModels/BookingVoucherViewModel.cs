using TravelAgency.Models;

namespace TravelAgency.ViewModels
{
    public class BookingVoucherViewModel
    {
        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
            }
        }

        public Hotel SelectedHotel { get; set; }
    }
}
