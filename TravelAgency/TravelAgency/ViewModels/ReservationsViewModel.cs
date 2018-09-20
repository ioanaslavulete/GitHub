using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;
using TravelAgency.Services;

namespace TravelAgency.ViewModels
{
	public class ReservationsViewModel
	{
		private ReservationRepository _reservationRepository;

		public ReservationsViewModel()
		{
			_reservationRepository = DataManagementService.Instance.MainRepository.ReservationRepository;
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
	}
}
