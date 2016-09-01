using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
   public class RemainderService
    {
        private DBModelContext db = null;

        //Constructors
        public RemainderService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from reminder in db.Reminders
                        where reminder.id == id
                        select reminder;
        }

        public List<Reminder> GetAll()
        {
            return db.Reminders.ToList();
        }

        public void insert(Reminder reminder)
        {
            db.Reminders.Add(reminder);
            db.SaveChanges();
        }

        public void Update(int id, Reminder _reminder)
        {
            var reminder = db.Reminders.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Reminders.Add(reminder);
            db.SaveChanges();
        }
    }
}
