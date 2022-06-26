using eDISC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eDISC.Models;

namespace eDISC.Controllers
{
    public class DiscController : Controller
    {
        private readonly IDiscRepository _discRepo;

        public DiscController(IDiscRepository discRepo)
        {
            _discRepo = discRepo;
        }



        // GET: DiscController
        public ActionResult Index()
        {
            List<Disc> discs = _discRepo.GetAllDiscs();
            return View(discs);
        }

        // GET: DiscController/Details/5
        public ActionResult Details(int id)
        {
            Disc disc = _discRepo.GetDiscById(id);
            if(disc == null)
            {
                return NotFound();
            }
            return View(disc);
        }

        // GET: DiscController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DiscController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DiscController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
