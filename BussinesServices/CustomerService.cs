using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices {  

    public class CustomerService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public CustomerService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from customer in db.Customers
                        where customer.id == id
                        select customer;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public void insert(Customer _customer)
        {
            db.Customers.Add(_customer);
            db.SaveChanges();
        }

        public void update(int id, Customer _customer)
        {
            var customer = db.Customers.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}