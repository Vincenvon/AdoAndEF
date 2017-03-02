using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Person> Persons { get; }
        void DeleteData(int ID);
        void EditData(Person pers);

        void CreateData(Person pers);
    }
}
