using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
  public  class ProductService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public ProductService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from product  in db.Products
                        where product.id == id
                        select product;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Update(int id, Product _product)
        {
            var product = db.Products.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}
