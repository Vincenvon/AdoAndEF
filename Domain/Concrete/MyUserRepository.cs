using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class MyUserRepository:IProductRepository
    {
        private string str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True";
        private DataBase db;
        public MyUserRepository() {
            db = new DataBase(str);
        }
        public IQueryable<Person> Persons {
        get {
                return db.GetData().AsQueryable<Person>();
            } }
        public void DeleteData(int ID) {
            db.DeleteData(ID);
        }
        public void EditData(Person pers)
        {
            db.EditData(pers);
        }
        public void CreateData(Person pers) {
            db.CreateData(pers);
        }
    }
}
