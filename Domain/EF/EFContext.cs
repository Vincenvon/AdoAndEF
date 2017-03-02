using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.EF
{
    public class EFContext:DbContext
    {
        
        public DbSet<Person> Persons { set; get; }
    }
}
