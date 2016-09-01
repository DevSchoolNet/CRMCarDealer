using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;

namespace BussinesServices
{
    public class OrderService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public OrderService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from order in db.Orders
                        where order.id == id
                        select order;
        }

        public List<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public void insert(Order _order)
        {
            db.Orders.Add(_order);
            db.SaveChanges();
        }

        public void update(int id, Order _order)
        {
            var order = db.Orders.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}
