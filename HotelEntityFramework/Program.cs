﻿using System;
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
                    select new { h.Name, h.Address, r.Room_No, r.Types, r.Price };

                Console.WriteLine("VærelsesInfo:");

                foreach (var h in værelsesInfo)
                {
                    Console.WriteLine(h.ToString());
                }

            }

        }
    }
}
