using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
	public class ReservationRepository
	{
		private ObservableCollection<Reservation> _reservationList;

		public ReservationRepository()
		{
			_reservationList = new ObservableCollection<Reservation>();
		}

		public ObservableCollection<Reservation> ReservationList
		{
			get
			{
				return _reservationList;
			}

			set
			{
				_reservationList = value;
			}
		}

		public void Add(Reservation reservation)
		{
			_reservationList.Add(reservation);
		}
	}
}
