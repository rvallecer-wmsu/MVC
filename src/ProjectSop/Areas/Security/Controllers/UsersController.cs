using ProjectSop.Areas.Security.Models;
using System;
using ProjectSop.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSop.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        private IList<UserView> Users
        {
            get
            {
                if(Session["data"]==null)
                {
                    Session["data"] = new List<UserView>(){
                        new UserView {
                            Id = Guid.NewGuid(),
                            Firstname = "Mukha",
                            Lastname = "Mo",
                            Age = 18,
                            Gender= "male",
                        },
                        new UserView {
                            Id= Guid.NewGuid(),
                            Firstname = "Pino",
                            Lastname = "kyo",
                            Age = 23,
                            Gender= "male",
                        },
                    };
                }
                return Session["data"] as List<UserView>;
            }
        }
        // GET: Security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserView
         {
             Id = user.Id,
             Firstname = user.Firstname,
             Lastname = user.Lastname,
             Age = user.Age,
             Gender = user.Gender
         }).ToList();
                return View(users);
           }
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            var i = Users.FirstOrDefault(user => user.Id == id);
            return View(i);
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender= new List<SelectListItem>(){
                new SelectListItem
                {
                    Value= "Male",
                    Text= "Male"
                },
                new SelectListItem
                {
                    Value= "Female",
                    Text= "Female"
                }
            };


            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserView ViewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();

                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Firstname = ViewModel.Firstname,
                        Lastname = ViewModel.Lastname,
                        Age = ViewModel.Age,
                        Gender = ViewModel.Gender
                    });

                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Gender = new List<SelectListItem>(){
                new SelectListItem
                {
                    Value= "Male",
                    Text= "Male"
                },
                new SelectListItem
                {
                    Value= "Female",
                    Text= "Female"
                }

            };
    
            var a = Users.FirstOrDefault(user => user.Id == id);
            return View();
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserView ViewModel)
        {
            try
            {
                // TODO: Add update logic here
                var i = Users.FirstOrDefault(user => user.Id == id);
                i.Firstname = ViewModel.Firstname;
                i.Lastname = ViewModel.Lastname;
                i.Age = ViewModel.Age;
                i.Gender = ViewModel.Gender;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, UserView ViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                var u = Users.FirstOrDefault(user => user.Id == id);
                Users.Remove(u);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
