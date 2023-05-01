using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Models
{
    public class Package
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public int PackagePrice { get; set; }
        public Hotel Hotel { get; set; }
        public Airfare Airfare { get; set; }
        public Client Client { get; set; }

    }
}