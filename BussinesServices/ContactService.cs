using System.Collections.Generic;
using System.Linq;
using DBModels;

namespace BussinesServices
{
    public class ContactService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public ContactService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from contact in db.Contacts
                        where contact.id == id
                        select contact;
        }

        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public void insert(Contact _contact)
        {
            db.Contacts.Add(new Contact(_contact.email, _contact.telephone));
            db.SaveChanges();
        }

        public void update(int id, Contact _contact)
        {
            var contact = db.Contacts.Where(u => u.id == id).FirstOrDefault();
            
            //to-do
            //...

            db.Contacts.Add(contact);
            db.SaveChanges();
        }


    }
}
