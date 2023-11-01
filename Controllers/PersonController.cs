using Microsoft.AspNetCore.Mvc;
using Tutorials.Models.Domain;

namespace Tutorials.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _context;
        public PersonController(DatabaseContext context) 
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "Hello World";
            ViewData["greeting2"] = "I am using viewData";
            //ViewBag and ViewData can send data only from controller to view

            //TemData can send data from one controller method to another controller method
            TempData["greeting3"] = "Its TempData";
            return View();
        }

        // it is a get method
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Person.Add(person);
                _context.SaveChanges();
                TempData["msg"] = "Added succesfuly";
                return RedirectToAction("AddPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Added";
           
                return View();
            }
            
        }
        public IActionResult DisplayPersons() 
        {
            var persons = _context.Person.ToList();
            return View(persons);
        }
        
        public IActionResult EditPerson(int id)
        {
            var person = _context.Person.Find(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Person.Update(person);
                _context.SaveChanges();
               
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Updated";

                return View();
            }

        }
        
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _context.Person.Find(id);
                if (person != null)
                {
                    _context.Person.Remove(person);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                
            }

            return RedirectToAction("DisplayPersons");
        }
    }
}
