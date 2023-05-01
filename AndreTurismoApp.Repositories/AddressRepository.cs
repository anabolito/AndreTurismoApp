using AndreTurismoApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;

namespace AndreTurismoApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private string Conn { get; set; }

        public AddressRepository()
        {
            Conn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\USERS\ADM\ONEDRIVE\DOCUMENTOS\ANDRETURISM.MDF;";
        }

        public bool Insert(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                if(new CityRepository().GetById(address.City.Id) == null)
                {
                    address.City = new CityRepository().Insert(address.City);
                }
                db.ExecuteScalar(Address.INSERT, new { @Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
                db.Close();
            }
            return status;
        }

        public bool Delete(int id)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
               
                db.Open();
                var result = db.Execute(Address.DELETE, new { @Id = id });
                status = true;
                db.Close();

            }
            return status;
        }

        
        public bool Update(Address address)
        {
            var status = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.ExecuteScalar(Address.UPDATE, new { @Street = address.Street, @Number = address.Number, @Neighborhood = address.Neighborhood, @PostalCode = address.PostalCode, @IdCity = address.City.Id });
                status = true;
                db.Close();
            }
            return status;
        }

        public List<Address> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var addresses = db.Query<Address, City, Address>(Address.GETALL, (address, city) =>
                {
                    address.City = city;
                    return address;
                }, splitOn: "SplitIdCity");
                return (List<Address>)addresses;
            }
        }

        public Address? GetById(int id)
        {
            using (var db = new SqlConnection(Conn))
            {
                var address = db.QueryFirstOrDefault<Address>(Address.GETBYID, new { @Id = id });
                return (Address)address;
            }
        }
    }
}