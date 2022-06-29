using eDISC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eDISC.Models;
using System;

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
            List<Disc> discs = _discRepo.GetAllDiscsForSale();
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
        public ActionResult Create(Disc disc)
        {
            try
            {
                _discRepo.AddDisc(disc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(disc);
            }
        }

        // GET: DiscController/Edit/5
        public ActionResult Edit(int id)
        {
            Disc disc = _discRepo.GetDiscById(id);
            if(disc == null)
            {
                return NotFound();
            }
            return View(disc);
        }

        // POST: DiscController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disc disc)
        {
            try
            {
                _discRepo.UpdateDisc(disc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(disc);
            }
        }

        // GET: DiscController/Delete/5
        public ActionResult Delete(int id)
        {
            Disc disc = _discRepo.GetDiscById(id);
            return View(disc);
        }

        // POST: DiscController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Disc disc)
        {
            try
            {
                _discRepo.DeleteDisc(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(disc);
            }
        }
    }
}
