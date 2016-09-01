using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;

namespace BussinesServices
{
    class SalesmanService
    {
        private DBModelContext db = null;

        //Constructors
        public SalesmanService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from salesman in db.Salesmen
                        where salesman.id == id
                        select salesman;
        }

        public List<Salesman> GetAll()
        {
            return db.Salesmen.ToList();
        }

        public void insert(Salesman _salesman)
        {
            db.Salesmen.Add(_salesman);
            db.SaveChanges();
        }

        public void Update(int id, Salesman _salesman)
        {
            var salesman = db.Salesmen.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Salesmen.Add(salesman);
            db.SaveChanges();
        }
    }
}
