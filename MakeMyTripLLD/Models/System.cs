



namespace MakeMyTripLLD.Models
{
    internal class System
    {
        private List<Flight> flights { get; set; }
        private static System instance { get; set; }

        private System() {
            flights=new List<Flight>();
        }

        public static System GetInstance()
        {
            if(System.instance == null)
            {
                System.instance = new System();
            }
            return System.instance;
        }
        public List<Flight> FetchFlights(string src,string dest,DateTime date)
        {
            List<Flight> Flights = new List<Flight>();
            List<Flight> FilteredFlights = new();

            foreach(Flight Flight in Flights)
            {
                if(Flight.src==src && Flight.dest==dest && Flight.date == date){
                    FilteredFlights.Add(Flight);
                }
            }

            return FilteredFlights;
        }

        public bool FixSeat(Customer customer,Flight flight,string seatid)
        {
            try
            {
                if (this.flights.Contains(flight))
                {
                    if (flight.airCraft.seats.Keys.Contains(seatid) && flight.airCraft.seats[seatid].customer==null)
                    {
                        flight.airCraft.seats[seatid].customer = customer;
                        return true;
                    }
                }
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool CancelSeat(Customer customer, Flight flight)
        {
            try
            {
                if (this.flights.Contains(flight))
                {
                    foreach(var seat in flight.airCraft.seats.Values) { 
                        if (seat.customer==customer)
                        {
                            seat.customer = null;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool AddFlight(Flight flight)
        {
            this.flights.Add(flight);
            return true;
        }

        public bool CancelFlight(Flight flight)
        {
            try
            {
                if (this.flights.Contains(flight))
                {
                    foreach(var seat in flight.airCraft.seats.Values)
                    {
                        seat.customer = null;
                    }
                }
                return true;
            }
            catch(Exception e)
            {
                return true;
            }
        }
    }
}
