using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TravelAgency.Models.Interfaces
{
	public interface IAccomodation
	{
		string Id { get; set; }
		Location Location { get; set; }
		string Name { get; set; }
		string NumberOfStars { get; set; }
		ObservableCollection<IRoom> RoomList { get; set; }
		ObservableCollection<IRoom> AvailableRoomsList { get; set; }

		void Add(IRoom newRoom);
		ObservableCollection<IRoom> GetBestOptionFor(Reservation reservation);
		bool HasRoomsAvailableIn(ReservationPeriod reservationPeriod);
		bool HasSameLocationAs(Location selectedLocation);
        bool IsValid();

		event PropertyChangedEventHandler PropertyChanged;
	}
}