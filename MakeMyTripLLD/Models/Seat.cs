

using MakeMyTripLLD.Enums;

namespace MakeMyTripLLD.Models
{
    
    internal class Seat
    {
        public SeatType seatType { get; set; }

        public string id { get; set; }

        public Customer customer { get; set; }
    }
}
