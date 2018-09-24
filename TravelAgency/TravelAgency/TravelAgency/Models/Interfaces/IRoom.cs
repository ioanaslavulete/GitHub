using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TravelAgency.Models.Interfaces
{
	public interface IRoom
	{
		string NumberOfPersons { get; set; }
		Price Price { get; set; }
		ObservableCollection<ReservationPeriod> ReservedPeriodList { get; set; }
		RoomViewType RoomViewType { get; set; }

		void Add(ReservationPeriod newReservationPeriod);
		void Delete(ReservationPeriod reservationPeriod);
		bool IsAvailableIn(ReservationPeriod reservationPeriod);

		event PropertyChangedEventHandler PropertyChanged;
	}
}