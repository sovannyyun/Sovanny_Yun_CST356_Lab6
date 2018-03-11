using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sovanny_Yun_CST356_Lab3.Data;
using Sovanny_Yun_CST356_Lab3.Data.Entities;
using Sovanny_Yun_CST356_Lab3.Models.View;

namespace Sovanny_Yun_CST356_Lab3.Controllers
{
    public class MajorController : Controller
    {
        // GET: Major
        public ActionResult Index(int userId)
        {
            ViewBag.UserId = userId;                // Pass-in all id for each user
            var majors = GetMajorsForUser(userId);

            return View(majors);
        }

        [HttpGet]
        public ActionResult Create(int userId)
        {
            ViewBag.UserId = userId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(MajorViewModel majorViewModel)
        {
            if (ModelState.IsValid)
            {
                Save(majorViewModel);
                return RedirectToAction("Index", new { UserId = majorViewModel.UserId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var major = GetMajor(id);

            return View(major);
        }

        [HttpPost]
        public ActionResult Edit(MajorViewModel majorViewModel)
        {
            if (ModelState.IsValid)
            {
                UpdateMajor(majorViewModel);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var major = GetMajor(id);

            DeleteMajor(id);

            return RedirectToAction("Index", new { UserId = major.UserId });
        }

        private Major GetMajor(int majorId)
        {
            var dbContext = new AppDbContext();

            return dbContext.Majors.Find(majorId);
        }

        private ICollection<MajorViewModel> GetMajorsForUser(int userId)
        {
            var majorViewModels = new List<MajorViewModel>();

            var dbContext = new AppDbContext();

            var majors = dbContext.Majors.Where(major => major.UserId == userId).ToList();

            foreach (var major in majors)
            {
                var majorViewModel = MapToMajorViewModel(major);
                majorViewModels.Add(majorViewModel);
            }

            return majorViewModels;
        }

        private void Save(MajorViewModel majorViewModel)
        {
            var dbContext = new AppDbContext();

            var major = MapToMajor(majorViewModel);

            dbContext.Majors.Add(major);

            dbContext.SaveChanges();
        }

        private void UpdateMajor(MajorViewModel majorViewModel)
        {
            var dbContext = new AppDbContext();

            var major = dbContext.Majors.Find(majorViewModel.Id);

            CopyToMajor(majorViewModel, major);

            dbContext.SaveChanges();
        }

        private void DeleteMajor(int id)
        {
            var dbContext = new AppDbContext();

            var major = dbContext.Majors.Find(id);

            if (major != null)
            {
                dbContext.Majors.Remove(major);
                dbContext.SaveChanges();
            }
        }

        private Major MapToMajor(MajorViewModel majorViewModel)
        {
            return new Major
            {
                Id = majorViewModel.Id,
                Subject = majorViewModel.Subject,
                Status = majorViewModel.Status,
                YearOfGraduate = majorViewModel.YearOfGraduate,
                UserId = majorViewModel.UserId
            };
        }

        private MajorViewModel MapToMajorViewModel(Major major)
        {
            return new MajorViewModel
            {
                Id = major.Id,
                Subject = major.Subject,
                Status = major.Status,
                YearOfGraduate = major.YearOfGraduate,
                UserId = major.UserId
            };
        }

        private void CopyToMajor(MajorViewModel majorViewModel, Major major)
        {
            major.Id = majorViewModel.Id;
            major.Subject = majorViewModel.Subject;
            major.Status = majorViewModel.Status;
            major.YearOfGraduate = majorViewModel.YearOfGraduate;
            major.UserId = majorViewModel.UserId;
        }
    }
}