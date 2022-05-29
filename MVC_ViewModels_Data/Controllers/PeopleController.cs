using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_ViewModels_Data.Models;
using MVC_ViewModels_Data.Data;

namespace MVC_ViewModels_Data.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ExDbContext _context;

        public PeopleController(IPeopleService peopleService, ExDbContext context)
        {
            _peopleService = peopleService;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View(_peopleService.All());
        }



        [HttpPost]
         public IActionResult Index(PeopleViewModel peopleviewModel)
         {
             peopleviewModel = _peopleService.FindBy(peopleviewModel);
             return View(peopleviewModel);
         }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel)
        {

            if (ModelState.IsValid)
            {

                _peopleService.Add(personViewModel);
                return RedirectToAction(nameof(Index));
            }

            return View(personViewModel);
        }


        public IActionResult DeletePerson(int id)
        {
            _peopleService.Remove(id);

            return RedirectToAction(nameof(Index));
        }
    

    }
}
