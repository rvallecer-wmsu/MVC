using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Security.Models;
using WebApplication1.Dal;

namespace WebApplication1.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {
                ViewBag.Gender = new List<SelectListItem>{
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },

                new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                }
            };
            ViewBag.Gender = Gender;
            }
        }
        // GET: Security/Users
    public ActionResult Index()
        {    
             using( var db=new DatabaseContext())
                {
                    var users = (from user in db.Users
                                 select new UserView
                {
                    Id = user.Id,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                    Age = user.Age,
                    Gender = user.Gender
                }).ToList();
                 return View(users);  
             }
    }


        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            return View(GetUser(Id));
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new List<SelectListItem> 
            {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },

                new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                }
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserView viewmodel)
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
                         FirstName = viewmodel.FirstName,
                         LastName = viewmodel.LastName,
                         Age = viewmodel.Age,
                         Gender = viewmodel.Gender

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
           
            return View(GetUser(id));
        }   
        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserView viewmodel)
        {
            try
            {

                using (var db = new DatabaseContext())
                {
                var user = db.Users.FirstOrDefault(u => u.Id = id);
                user.FirstName = viewmodel.Firstname;
                user.LastName = viewmodel.Lastname;
                user.Age = viewmodel.Age;
                user.Gender = viewmodel.Gender;

                db.SaveChanges();
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
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
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
