using eDISC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using eDISC.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using eDISC.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace eDISC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [Authorize]
        // GET: UserController
        public ActionResult Index()
        {
            List<User> users = _userRepo.GetAllUsers();
            return View(users);
        }

        [Authorize]
        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
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
                user.UserTypeId = 2;
                _userRepo.AddUser(user);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return View(user);
            }
        }

        [Authorize]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(User user)
        {
            try
            {
                user.UserTypeId = 1;
                _userRepo.AddUser(user);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(user);
            }
        }

        [Authorize]
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            //need VM that adds a list of usertypes. 

            UserViewModel vm = new UserViewModel();
            vm.User = _userRepo.GetUserById(id);
            if(vm.User == null)
            {
                return NotFound();
            }
            vm.UserTypes = _userRepo.GetUserTypes();
            return View(vm);
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

        [Authorize]
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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            User user = _userRepo.GetUserByEmail(viewModel.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserTypeId == 1 ? "Admin" : "User"),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Disc");
        }

        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
