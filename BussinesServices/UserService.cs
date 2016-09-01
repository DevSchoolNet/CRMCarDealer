using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    class UserService
    {
        private DBModelContext db = null;

        //Constructors
        public UserService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from user in db.Users
                        where user.id == id
                        select user;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void insert(User _user)
        {
            db.Users.Add(_user);
            db.SaveChanges();
        }

        public void Update(int id, User _user)
        {
            var user = db.Users.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
