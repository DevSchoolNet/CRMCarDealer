using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    class DriveTestService
    {
        //Db
        private DBModelContext db = null;

        //Constructors
        public DriveTestService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from driveTest in db.DriveTests
                        where driveTest.id == id
                        select driveTest;
        }

        public List<DriveTest> GetAll()
        {
            return db.DriveTests.ToList();
        }

        public void insert(DriveTest driveTest)
        {
            db.DriveTests.Add(driveTest);
            db.SaveChanges();
        }

        public void update(int id, DriveTest driveTest)
        {
            var drive_test = db.DriveTests.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.DriveTests.Add(drive_test);
            db.SaveChanges();
        }

    }
}