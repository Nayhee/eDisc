﻿using eDISC.Repositories;
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
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;
        private readonly IDiscRepository _discRepo;
        private readonly IUserRepository _userRepo;

        public ActionResult AddToCart(int id)
        {
            //first see if they already have a cart.
            //if they do, add disc to that cart. Otherwise 
            int userId = GetCurrentUserId();
            Disc discToAdd = _discRepo.GetDiscById(id);
            //they are viewing details and click add to cart for the disc they want to buy. 
            //ID gets passed here, then  I add product to cart and return view to the same details page. 
        }

        public ActionResult Cart(Cart cart) //not sure what to pass in 
        {

            return View(cart);
        }

        // GET: CartController
        public ActionResult Index()
        {
            //will need to make sure they're logged in to see the cart view!!
            //ALSO ONLY LET THEM SEE THE CART IN NAVBAR ONCE THEY'VE ADDED SOMETHING TO CART

            //get current user ID, then use ID to grab their most recent Cart. Throw that cart into thew view. 
            return View();
        }

       
        //DONT THINK I NEED THIS
        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
