namespace TravelAgency.Models
{
    public class AvailableOption
    {
        private Hotel _hotel;

        public AvailableOption()
        {
        }

        public AvailableOption(Hotel hotel)
        {
            _hotel = hotel;
        }

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
