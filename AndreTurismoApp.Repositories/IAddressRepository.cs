using AndreTurismoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreTurismoApp.Repositories
{
    public interface IAddressRepository
    {
        bool Insert(Address address);
        bool Delete(int id);
        bool Update(Address address);
        List<Address> GetAll();
    }
}
