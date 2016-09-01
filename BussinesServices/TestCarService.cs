using DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesServices
{
    public class TestCarService
    {
        private DBModelContext db = null;

        //Constructors
        public TestCarService()
        {
            db = new DBModelContext();
        }

        //Db API
        public void GetByID(int id)
        {
            var query = from testCar in db.TestCars
                        where testCar.id == id
                        select testCar;
        }

        public List<TestCar> GetAll()
        {
            return db.TestCars.ToList();
        }

        public void insert(TestCar testCar)
        {
            db.TestCars.Add(testCar);
            db.SaveChanges();
        }

        public void Update(int id, TestCar testCar)
        {
            var test_car = db.TestCars.Where(u => u.id == id).FirstOrDefault();

            //to-do
            //...

            db.TestCars.Add(test_car);
            db.SaveChanges();
        }
    }
}
