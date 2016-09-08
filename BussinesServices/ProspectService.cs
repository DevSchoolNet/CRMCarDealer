using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    public class ProspectService
    {
        private DBModelContext db = null;

        //Constructors
        public ProspectService()
        {
            db = new DBModelContext();
        }

        //Db API
        public Prospect GetByID(decimal id)
        {
            var query = from prospect in db.Prospects
                        where prospect.id == id
                        select prospect;

	        return query.FirstOrDefault();
        }

        public List<Prospect> GetAll()
        {
            return db.Prospects.ToList();
        }

        public void insert(Prospect prospect)
        {
            db.Prospects.Add(prospect);
            db.SaveChanges();
        }

        public void Update(int id, Prospect _prospect)
        {
            var prospect = db.Prospects.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Prospects.Add(prospect);
            db.SaveChanges();
        }
    }
}
