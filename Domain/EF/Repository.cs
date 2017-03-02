using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.EF
{
    public class Repository:IPersonRepository
    {
        private EFContext context = new EFContext();
        public IQueryable<Person> Persons
        {
            get { return context.Persons;}
        }

        public void CreateData(Person pers) {
            context.Persons.Add(pers);
            context.SaveChanges();

        }

        public void EditData(Person pers) {
            Person temp = context.Persons.Where(p => p.ID == pers.ID).FirstOrDefault();
            if (temp != null) {
                temp.Age = pers.Age;
                temp.FirstName = pers.FirstName;
                temp.LastName = pers.LastName;
                temp.Sex = pers.Sex;
                context.SaveChanges();
            }
            
        }

        public void DeleteData(int ID) {
            var person = context.Persons.Where(p => p.ID == ID).FirstOrDefault();
            if (person!=null) {
                context.Persons.Remove(person);
                context.SaveChanges();
            }
        }
    }
}
