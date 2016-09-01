using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    public class ProductDetailService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public ProductDetailService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from productDetail in db.ProductDetails
                        where productDetail.product_id == id
                        select productDetail;
        }

        public List<ProductDetail> GetAll()
        {
            return db.ProductDetails.ToList();
        }

        public void insert(ProductDetail productDetails)
        {
            db.ProductDetails.Add(productDetails);
            db.SaveChanges();
        }

        public void Update(int id, ProductDetail _productDetails)
        {
            var productDetail = db.ProductDetails.Where(u => u.product_id == id).FirstOrDefault();

            //to-do
            //...

            db.ProductDetails.Add(productDetail);
            db.SaveChanges();
        }
    }
}
