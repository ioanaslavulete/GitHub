using System;
using System.Collections.ObjectModel;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
	[Serializable]
	public class AccomodationRepository
	{
		private ObservableCollection<IAccomodation> _accomodationList;

		public AccomodationRepository()
		{
			_accomodationList = new ObservableCollection<IAccomodation>();
		}

		public ObservableCollection<IAccomodation> HotelList
		{
			get { return _accomodationList; }
			set
			{
				_accomodationList = value;
			}
		}

		public void Add(IAccomodation newHotel)
		{
			_accomodationList.Add(newHotel);
		}

		public void Delete(IAccomodation selectedHotel)
		{
			_accomodationList.Remove(selectedHotel);
		}
	}
}
