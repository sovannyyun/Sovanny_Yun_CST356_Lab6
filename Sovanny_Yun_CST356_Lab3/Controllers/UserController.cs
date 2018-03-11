using Sovanny_Yun_CST356_Lab3.Data;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var users = GetAllUsers();

            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = MapToUser(userViewModel);

                SaveUser(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = GetUser(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateUser(userViewModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteUser(id);

            return RedirectToAction("Index");
        }

        private UserViewModel GetUser(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            return MapToUserViewModel(user);
        }

        private IEnumerable<UserViewModel> GetAllUsers()
        {
            var userViewModels = new List<UserViewModel>();

            var dbContext = new AppDbContext();

            foreach (var user in dbContext.Users)
            {
                var userViewModel = MapToUserViewModel(user);
                userViewModels.Add(userViewModel);
            }

            return userViewModels;
        }

        private void SaveUser(User user)
        {
            var dbContext = new AppDbContext();

            dbContext.Users.Add(user);

            dbContext.SaveChanges();
        }

        private void UpdateUser(UserViewModel userViewModel)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(userViewModel.Id);

            CopyToUser(userViewModel, user);

            dbContext.SaveChanges();
        }

        private void DeleteUser(int id)
        {
            var dbContext = new AppDbContext();

            var user = dbContext.Users.Find(id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
        }

        private User MapToUser(UserViewModel userViewModel)
        {
            return new User
            {
                Id = userViewModel.Id,
                FirstName = userViewModel.FirstName,
                MiddleName = userViewModel.MiddleName,
                LastName = userViewModel.LastName,
                EmailAddress = userViewModel.EmailAddress,
                DateOfBirth = userViewModel.DateOfBirth,
                YearInSchoo = userViewModel.YearInSchool
            };
        }

        private UserViewModel MapToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                DateOfBirth = user.DateOfBirth,
                YearInSchool = user.YearInSchoo
            };
        }

        private void CopyToUser(UserViewModel userViewModel, User user)
        {
            user.FirstName = userViewModel.FirstName;
            user.MiddleName = userViewModel.MiddleName;
            user.LastName = userViewModel.LastName;
            user.EmailAddress = userViewModel.EmailAddress;
            user.DateOfBirth = userViewModel.DateOfBirth;
            user.YearInSchoo = userViewModel.YearInSchool;
        }

        /* EXERCISE 1
        // GET: User
        public ActionResult Index()
        {
            return View(GetAllUsers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            SaveUser(user);
            return RedirectToAction("Index");
        }

        private void SaveUser(User user)
        {
            var dbContext = new AppDbContext();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        private IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            var dbContext = new AppDbContext();

            foreach (var user in dbContext.Users)
            {
                users.Add(user);
            }

            return users;
        }
        */
    }
}