using MakeMyTripLLD.Enums;


namespace MakeMyTripLLD.Models
{
    
    internal class User
    {
        public string id { get; set; }

        public string name { get; set; }    

        public string email { get; set; }

        public System system { get; set; }

        public UserType userType { get; set; }

        public User(string id,string name,string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }


    }
    internal class Customer : User
    {
        
        public Customer(string id,string name,string email):base(id,name,email)
        {
            this.userType = UserType.CUSTOMER;
            this.system = System.GetInstance();
        }
        public List<Flight> fetchFlights(string src,string dest,DateTime date)
        {
            return this.system.FetchFlights(src, dest, date);
        }
        public bool fixSeat(Flight flight,Seat seat)
        {
            return this.system.FixSeat(this, flight, seat.id);
        }
        public bool cancelBookingFlight(Flight flight)
        {
            return this.system.CancelFlight(flight);
        }
    }

    internal class Admin : User
    {
        public Admin(string id, string name, string email) : base(id, name, email)
        {
            this.userType = UserType.ADMIN;
            this.system = System.GetInstance();
        }

        public bool AddFlight(Flight flight)
        {
            return this.system.AddFlight(flight);
        }

        public bool CancelFlight(Flight flight) { 
            return this.system.CancelFlight(flight);
        }
    }
}
