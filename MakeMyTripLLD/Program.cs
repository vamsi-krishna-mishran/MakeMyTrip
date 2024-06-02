using MakeMyTripLLD.Enums;
using MakeMyTripLLD.Logger;
using MakeMyTripLLD.Models;

namespace MakeMyTripLLD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger.Logger();

            BookATicket(logger);
        }
        static void BookATicket(ILogger logger)
        {
            //creating a customer
            string id = "C001";
            string name = "Vamsi Krishna";
            string email = "vamsi@gmail.com";
            Customer customer = new Customer(id, name, email);

            //creating Admin
            string aid = "A001";
            string aname = "Gaurav";
            string aemail = "gaurav@gmail.com";
            Admin admin = new Admin(aid,aname,aemail);

            //creating a Flight
            Flight flight=new Flight();
            flight.id = "F01";

            //creating AirCraft
            AirCraft aircraft = new AirCraft();

            //creating seat 
            Seat seat=new Seat();

            //setting properties of seat object
            seat.id = "SNO01";
            seat.seatType = SeatType.ECONOMIC;
            
            //adding the seat to aircraft 
            aircraft.addSeat(seat);
            aircraft.airCraftId = "ANO001";

            //adding aircraft to the flight object

            flight.airCraft = aircraft;
            flight.startTime = DateTime.Now;
            flight.endTime = DateTime.Now;

            //adding flight to the system
            if (admin.AddFlight(flight))
            {
                logger.Log($"added flight with id {flight.id}");
            }
            else
            {
                logger.Log($"Failed to add flight with id {flight.id}");
            }

            if(customer.fixSeat(flight, seat)){
                logger.Log($"booked the seat with seat id{seat.id} for flight {flight.id}");
            }
            else
            {
                logger.Log($"Failed to book the seat");
            }
            customer.cancelBookingFlight(flight);

            if (customer.fixSeat(flight, seat))
            {
                logger.Log($"booked the seat with seat id{seat.id} for flight {flight.id}");
            }
            else
            {
                logger.Log($"Failed to book the seat");
            }

        }
    }
}