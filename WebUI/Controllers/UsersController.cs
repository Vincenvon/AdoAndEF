using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUi.Controllers
{
    public class UsersController : Controller
    {
        private IPersonRepository repository;
        public UsersController(IPersonRepository productRepository)
        {
            this.repository = productRepository;
        }
        public ViewResult List() {
            return View(repository.Persons);
        }
        [HttpGet]
        public ViewResult FindListAge()
        {
            return View();
        }
        [HttpPost]
        public ViewResult FindListAge(Person pers)
        {
            return View("List",repository.Persons.Where(x=>
                                                            (pers.Age==0 || x.Age==pers.Age)&&
                                                            (String.IsNullOrEmpty(pers.FirstName) || x.FirstName==pers.FirstName) &&
                                                            (String.IsNullOrEmpty(pers.LastName) || x.LastName== pers.LastName) &&
                                                            (String.IsNullOrEmpty(pers.Sex)|| x.Sex == pers.Sex)));
          
        }


        [HttpGet]
        public ViewResult DeleteData(int id) {
            var forDelete = repository.Persons.Where(p => p.ID == id).FirstOrDefault();
            return View(forDelete);
        }

        [HttpPost]
        public ViewResult DeleteData(Person pers)
        {
            repository.DeleteData(pers.ID);
            return View("List", repository.Persons);
        }
        [HttpGet]
        public ViewResult EditData(int id) {

            return View(repository.Persons.FirstOrDefault(x=>x.ID==id));
        }

        [HttpPost]
        public ViewResult EditData(Person pers)
        {
            if (ModelState.IsValid)
            {
                repository.EditData(pers);
                return View("List", repository.Persons);
            }
            else
                return View(pers);
        }

        [HttpGet]
        public ViewResult CreateData() {
            return View(new Person());
        }
        [HttpPost]
        public ViewResult CreateData(Person pers)
        {
            if (ModelState.IsValid)
            {
                repository.CreateData(pers);
                return View("List", repository.Persons);
            }
            else
                return View(pers);
        }
    }
}