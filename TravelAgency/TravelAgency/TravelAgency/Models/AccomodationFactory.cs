using System;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
    public class AccomodationFactory
	{
		public IAccomodation BuildAccomodation(AccomodationType type)
		{
			switch (type)
			{
				case AccomodationType.Hotel:
					return new Hotel();
				case AccomodationType.Mansion:
					return new Hotel();
				default:
					throw new NotSupportedException();
			}
		}
	}
}
