using Domain.Entities;
using System.Data.Entity;

namespace Domain.EF
{
    public class EFContext:DbContext
    {
        
        public DbSet<Person> Persons { set; get; }
    }
}
