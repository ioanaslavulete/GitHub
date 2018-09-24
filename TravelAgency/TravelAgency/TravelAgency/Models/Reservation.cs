using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TravelAgency.Models.Interfaces;
using TravelAgency.ViewModels;

namespace TravelAgency.Models
{
	[Serializable]
	public class Reservation : INotifyPropertyChanged
	{
		private ReservationPeriod _reservationPeriod;
		private string _numberOfPersons;
		private Customer _owner;
		private IAccomodation _hotel;

		public Reservation()
		{
			_owner = new Customer();
			_reservationPeriod = new ReservationPeriod();
			_numberOfPersons = string.Empty;
		}

		public Reservation(Customer owner, IAccomodation hotel, ReservationPeriod reservationPeriod, string numberOfPersons, Option bestOption)
		{
			Owner = owner;
			Hotel = hotel;
			ReservationPeriod = reservationPeriod;
			NumberOfPersons = numberOfPersons;
			BestOption = bestOption;
		}

		public string NumberOfPersons
		{
			get { return _numberOfPersons; }
			set
			{
				_numberOfPersons = value;
			}
		}
		public ReservationPeriod ReservationPeriod
		{
			get { return _reservationPeriod; }
			set
			{
				_reservationPeriod = value;
			}
		}
		public Customer Owner
		{
			get { return _owner; }
			set
			{
				_owner = value;
				OnPropertyChanged();
			}
		}
		public IAccomodation Hotel
		{
			get { return _hotel; }
			set
			{
				_hotel = value;
			}
		}
		public Option BestOption { get; set; }

		public bool HasOwnerWithId(string id)
		{
			if (_owner.HasId(id))
				return true;
			return false;
		}

		[field: NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string caller = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(caller));
			}
		}
	}
}
