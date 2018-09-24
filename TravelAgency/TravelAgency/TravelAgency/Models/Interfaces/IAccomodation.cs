using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TravelAgency.Models.Interfaces
{
	public interface IAccomodation
	{
		ObservableCollection<Room> AvailableRoomsList { get; set; }
		string Id { get; set; }
		Location Location { get; set; }
		string Name { get; set; }
		string NumberOfStars { get; set; }
		ObservableCollection<Room> RoomList { get; set; }

		event PropertyChangedEventHandler PropertyChanged;

		void Add(Room newRoom);
		ObservableCollection<Room> GetBestOptionFor(Reservation reservation);
		bool HasRoomsAvailableIn(ReservationPeriod reservationPeriod);
		bool HasSameLocationAs(Location selectedLocation);
	}
}