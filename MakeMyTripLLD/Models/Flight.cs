namespace MakeMyTripLLD.Models
{
    internal class Flight
    {
        public string id { get; set; }
        public string src { get; set; }

        public string dest { get;set; } 

        public DateTime date { get; set; }

        public AirCraft airCraft { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        
        public bool cancelForCustomer(Customer customer)
        {
            try
            {
                var allSeats = this.airCraft.seats;
                foreach(var seat in allSeats.Values)
                {
                    if (seat.customer == customer)
                    {
                        seat.customer = null;
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool cancelSeat(string seatId)
        {
            try
            {
                foreach (var seatId2 in this.airCraft.seats.Keys)
                {
                    if (seatId2 == seatId)
                    {
                        this.airCraft.seats[seatId].customer = null;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }

    internal class AirCraft
    {
        public Dictionary<string,Seat> seats { get; set; }

        public string airCraftId { get; set; }

        public AirCraft()
        {
            seats = new Dictionary<string, Seat>();
        }

        public bool fixSeat(Customer customer,Seat seat)
        {
            try
            {
                foreach(string id in seats.Keys)
                {
                    if (id == seat.id)
                    {
                        var foundSeat = seats[id];
                        if (foundSeat.customer != null)
                        {
                            return false;//already booked.
                        }
                        foundSeat.customer = customer;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }
        public bool addSeat(Seat seat)
        {
            try
            {
                seats.Add(seat.id, seat);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
