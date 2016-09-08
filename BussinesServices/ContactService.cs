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

	    public Contact GetByEmail(string email)
	    {
		    var contact = (from co in db.Contacts
			    where co.email == email
			    select co).FirstOrDefault();
		    return contact;
	    }
        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public decimal insert(Contact _contact)
        {
            db.Contacts.Add(_contact);
            db.SaveChanges();
	        return _contact.id;
        }

	    public void DeleteById(decimal Id)
	    {
			var contact = ( from co in db.Contacts
							where co.id == Id
							select co ).FirstOrDefault();

		    if (contact != null)
		    {
			    var contactProspects = contact.Prospects.ToList();
			    for (int i = 0; i < contactProspects.Count; i++)
			    {
				    var  prospect = contactProspects[i];
					db.Prospects.Remove( prospect );
				}
				db.Contacts.Remove(contact);
			    db.SaveChanges();
		    }
	    }

        public void update(int id, Contact _contact)
        {
            var contact = db.Contacts.Where(u => u.id == id).FirstOrDefault();
            
            //to-do
            //...

            db.Contacts.Add(contact);
            db.SaveChanges();
        }


	    public void update(Contact contactFromDb)
	    {
			db.Contacts.Attach( contactFromDb );
			db.SaveChanges();
		}
    }
}
