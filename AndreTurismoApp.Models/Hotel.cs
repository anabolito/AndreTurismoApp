using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public double DailyPrice { get; set; }
        public Address HotelAddress { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
