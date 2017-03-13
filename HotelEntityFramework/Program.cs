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
                var hotelList =
                    from h in db.Hotel
                    select h;

                Console.WriteLine("Hotel informationer:");

                foreach (var h in hotelList)
                {
                    Console.WriteLine(h.ToString());
                }
            }

        }
    }
}
