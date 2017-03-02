using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class MyUserRepository:IPersonRepository
    {
        private string str; 
        private DataBase db;
        public MyUserRepository() {
            str = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True";
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
