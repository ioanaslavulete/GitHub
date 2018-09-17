using System;
using System.Collections.ObjectModel;

namespace TravelAgency.Models
{
    public class HotelRepository
    {
        private ObservableCollection<Hotel> _hotelList;

        public HotelRepository()
        {
            _hotelList = new ObservableCollection<Hotel>();
        }

        public ObservableCollection<Hotel> HotelList
        {
            get { return _hotelList; }
            set
            {
                _hotelList = value;
            }
        }

        public void Add(Hotel newHotel)
        {
            _hotelList.Add(newHotel);
        }

        public void Delete(Hotel selectedHotel)
        {
            _hotelList.Remove(selectedHotel);
        }
    }
}
