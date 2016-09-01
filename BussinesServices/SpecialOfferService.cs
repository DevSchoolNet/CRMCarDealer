using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModels;

namespace BussinesServices
{
    class SpecialOfferService
    {
        private DBModelContext db = null;

        //Constructors
        public SpecialOfferService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from specialOffer in db.SpecialOffers
                        where specialOffer.id == id
                        select specialOffer;
        }

        public List<SpecialOffer> GetAll()
        {
            return db.SpecialOffers.ToList();
        }

        public void insert(SpecialOffer _specialOffer)
        {
            db.SpecialOffers.Add(_specialOffer);
            db.SaveChanges();
        }

        public void Update(int id, SpecialOffer _specialOffer)
        {
            var specialOffer = db.SpecialOffers.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.SpecialOffers.Add(specialOffer);
            db.SaveChanges();
        }
    }
}
