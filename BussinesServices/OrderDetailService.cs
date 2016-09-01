using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    public class OrderDetailService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public OrderDetailService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from orderDetail in db.OrderDetails
                        where orderDetail.order_id == id
                        select orderDetail;
        }

        public List<OrderDetail> GetAll()
        {
            return db.OrderDetails.ToList();
        }

        public void insert(OrderDetail orderDetails)
        {
            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();
        }

        public void update(int id, OrderDetail orderDetails)
        {
            var order_Detail= db.OrderDetails.Where(u => u.order_id == id).FirstOrDefault();

            //to-do
            //...

            db.OrderDetails.Add(order_Detail);
            db.SaveChanges();
        }
    }
}
