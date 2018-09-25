using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Models
{
	[Serializable]
	public class ReservationRepository
	{
		private ObservableCollection<Reservation> _reservationList;
		private ObservableCollection<AccomodationReservation> _hotelReservationList;

		public ReservationRepository()
		{
			_reservationList = new ObservableCollection<Reservation>();
			_hotelReservationList = new ObservableCollection<AccomodationReservation>();
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
		public ObservableCollection<AccomodationReservation> HotelReservationList
		{
			get { return _hotelReservationList; }
			set
			{
				_hotelReservationList = value;
			}
		}

		public void Add(Reservation reservation)
		{
			_reservationList.Add(reservation);
		}

		public void Delete(Reservation selectedReservation)
		{
			_reservationList.Remove(selectedReservation);
		}

		public void AddHotelReservation(AccomodationReservation reservation)
		{
			_hotelReservationList.Add(reservation);
		}

		public void DeleteHotelReservation(AccomodationReservation reservation)
		{
			_hotelReservationList.Remove(reservation);
		}

		public Customer GetOwnerWithId(string id)
		{
			foreach (Reservation reservation in _reservationList)
			{
				if (reservation.HasOwnerWithId(id))
				{
					return reservation.Owner;
				}
			}
			return new Customer();
		}
	}
}
