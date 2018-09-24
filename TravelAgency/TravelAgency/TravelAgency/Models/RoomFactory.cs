using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models.Interfaces;

namespace TravelAgency.Models
{
   public class RoomFactory
    {
        public IRoom BuildRoom(RoomType roomType)
        {
            switch(roomType)
            {
                case RoomType.Room:
                    return new Room();
                default:
                    return new Room();
            }
        }
    }
}
