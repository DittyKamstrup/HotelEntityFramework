using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HotelContext())
            {

                // Opgave 2.1

                var hotelList =
                    from h in db.Hotel
                    select h;

                Console.WriteLine("Hotel informationer:");

                foreach (var h in hotelList)
                {
                    Console.WriteLine(h.ToString());
                }

                //Opgave 2.2

                var guestList =
                    from g in db.Guest
                    select g;

                Console.WriteLine("Gæsteliste:");

                foreach (var g in guestList)
                {
                    Console.WriteLine(g.ToString());
                }

                //Opgave 3.1 - List hotelnavn, adresse, samt værelsesinformation(nr, type, pris) om de værelser hotellerne har. 

                var værelsesInfo =
                    from h in db.Hotel
                    join r in db.Room
                        on h.Hotel_No equals r.Hotel_No
                    select new { Name = h.Name, Address = h.Address, Room_No = r.Room_No, Type = r.Types, Price = r.Price };

                Console.WriteLine("VærelsesInfo:");

                foreach (var h in værelsesInfo)
                {
                    Console.WriteLine(h.ToString());
                }

                //Opgave 3.2 - List alle de reservationer hver enkelt værelse har.


                var reservationer =
                    from r in db.Room
                    join b in db.Booking
                        on r.Room_No equals b.Room_No
                    select new { Room = r.Room_No, Booking = b.Room_No };

                Console.WriteLine("Reservationer:");

                foreach (var r in reservationer)
                {
                    Console.WriteLine(r.ToString());
                }
            }

        }
    }
}
