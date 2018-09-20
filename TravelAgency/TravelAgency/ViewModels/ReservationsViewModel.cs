using TravelAgency.Models;
using TravelAgency.Models.Commands;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
    public class ReservationsViewModel
	{
		private ReservationRepository _reservationRepository;
        private Reservation _selectedReservation;
        private CancelReservationCommand _cancelReservationCommand;

        public ReservationsViewModel()
		{
			_reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
            _cancelReservationCommand = new CancelReservationCommand(this);
		}

		public ReservationRepository ReservationRepository
		{
			get
			{
				return _reservationRepository;
			}

			set
			{
				_reservationRepository = value;
			}
		}
        public Reservation SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                _selectedReservation = value;
            }
        }
        public CancelReservationCommand CancelReservationCommand
        {
            get { return _cancelReservationCommand; }
            set
            {
                _cancelReservationCommand = value;
            }
        }

        public void CancelReservation()
        {
            foreach(Room room in _selectedReservation.Hotel.BestOption.Rooms)
            {
                room.Delete(_selectedReservation.ReservationPeriod);
            }
            _reservationRepository.Delete(_selectedReservation);
            DataManagementService.Instance.SaveData();
        }

    }
}
