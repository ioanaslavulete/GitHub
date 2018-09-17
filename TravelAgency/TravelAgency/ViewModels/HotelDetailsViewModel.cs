using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;

namespace TravelAgency.ViewModels
{
    public class HotelDetailsViewModel
    {
        private Hotel _selectedHotel;

        public Hotel SelectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                _selectedHotel = value;
            }
        } 
    }
}
