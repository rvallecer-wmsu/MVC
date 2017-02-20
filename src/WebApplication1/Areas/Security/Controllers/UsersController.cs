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
        private IList<UserView> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserView>(){
                        new UserView {
                            Id = Guid.NewGuid(),
                            FirstName = "John",
                            LastName = "Doe",
                            Age = 29,
                            Gender="Female"
                           
                        },
                        new UserView {
                            Id = Guid.NewGuid(),
                            FirstName = "Jane",
                            LastName = "Doe",
                            Age = 32,
                            Gender="Female"
                        },
                        new UserView {
                            Id = Guid.NewGuid(),
                            FirstName = "Lance",
                            LastName = "Vallecer",
                            Age = 20,
                            Gender="Male"
                        }
                    };
                }
                return Session["data"] as List<UserView>;
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
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
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
                    Users.Add(new UserView
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
           
            return View();
        }   
        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserView view)
        {
            try
            {
                var u = Users.FirstOrDefault(user => user.Id == id);
                u.FirstName = view.FirstName;
                u.LastName = view.LastName;
                u.Age = view.Age;
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
