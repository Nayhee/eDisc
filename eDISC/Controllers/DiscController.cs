using eDISC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eDISC.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using eDISC.Models.ViewModels;

namespace eDISC.Controllers
{
    public class DiscController : Controller
    {
        private readonly IDiscRepository _discRepo;
        private readonly IUserRepository _userRepo;

        public DiscController(IDiscRepository discRepo, IUserRepository userRepo)
        {
            _discRepo = discRepo;
            _userRepo = userRepo;
        }


        // GET: DiscController
        public ActionResult Index()
        {
            //DiscViewModel vm = new DiscViewModel();
            List<Disc> discs = _discRepo.GetAllDiscsForSale();
            
            //int currentUserId = GetCurrentUserId();
            //vm.User = _userRepo.GetUserById(currentUserId);

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
        [Authorize]
        public ActionResult Create()
        {
            DiscCreateViewModel vm = new DiscCreateViewModel();
            vm.Disc = new Disc();
            vm.Brands = _discRepo.GetAllBrands();
            
            return View(vm);
        }

        // POST: DiscController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disc disc)
        {
            try
            {
                disc.DiscTypeId = 1;
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

       



        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
