using ChildcareScouter.Models.EmployeeModel;
using ChildcareScouter.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService CreateEmployeeService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new EmployeeService(userID);
            return svc;
        }

        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new EmployeeService(userID);
            var model = svc.GetEmployees();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var svc = CreateEmployeeService();

            if (svc.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateEmployeeService();
            var detail = svc.GetEmployeeByID(iD);

            var model = new EmployeeEdit
            {

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EmployeeID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateEmployeeService();

            if (svc.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Your Provider was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Provider could not be permitted.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int iD)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateEmployeeService();

            svc.DeleteEmployee(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}