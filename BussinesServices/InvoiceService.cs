using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;

namespace BussinesServices
{
    public class InvoiceService
    {
        private DBModelContext db = null;

        public InvoiceService()
        {
            db = new DBModelContext();
        }

        public void GetByID(int id)
        {
            var query = from inv in db.Invoices
                        where inv.order_id==id
                        select inv;
        }

        public List<Invoice> GetAll()
        {
            return db.Invoices.ToList();
        }

        public void insert(Invoice _invoice)
        {
            db.Invoices.Add(_invoice);
            db.SaveChanges();
        }

        public void update(int id,Invoice invoice)
        {
            var inv = db.Invoices.Where(u => u.order_id == id).FirstOrDefault();
            inv.number = invoice.number;
            inv.series = invoice.series;
            inv.date = invoice.date;

            db.Invoices.Add(inv);
            db.SaveChanges();
        }


    }
}
