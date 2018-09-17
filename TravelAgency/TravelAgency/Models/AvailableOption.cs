namespace TravelAgency.Models
{
    public class AvailableOption
    {
        private Hotel _hotel;

        public Hotel Hotel
        {
            get { return _hotel; }
            set
            {
                _hotel = value;
            }
        }
    }
}
