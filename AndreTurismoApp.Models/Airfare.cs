using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Airfare
    {
        public int Id { get; set; } 
        public Address Origin { get; set; }
        public Address Destiny { get; set; }
        public Client Client { get; set; }
        public double Price { get; set; }
    }
}
