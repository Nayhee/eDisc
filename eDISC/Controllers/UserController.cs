using eDISC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eDISC.Models;
using System;

namespace eDISC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        
        
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _userRepo.AddUser(user);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(user);
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            User user = _userRepo.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _userRepo.UpdateUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user);
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            User user = _userRepo.GetUserById(id);
            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _userRepo.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(user);
            }
        }
    }
}
