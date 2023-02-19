using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstruturaTryCatch.Exceptions;

namespace EstruturaTryCatch.Entities
{
    internal class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }    

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("Check-Out date must be after check-in date");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            // catch duration with timeSpan
            TimeSpan duration = CheckOut.Subtract(CheckIn);

            // return duration in days
            return (int)duration.TotalDays;
        }


        public void UpadateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if(checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates ");
            }

            if(checkOut <= checkIn)
            {
                throw new DomainException("Check-Out date must be after check-in date");
            }

            CheckIn= checkIn;
            CheckOut= checkOut;
        }

        public override string ToString()
        {
            return "Room "
                + RoomNumber
                + ", check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out: "
                + ", "
                + Duration()
                + "nights";
        }
    }
}
