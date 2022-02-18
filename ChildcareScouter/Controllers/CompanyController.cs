using ChildcareScouter.Data;
using ChildcareScouter.Models.CompanyModel;
using ChildcareScouter.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyService CreateCompanyService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CompanyService(userID);
            return svc;
        }

        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyService(userID);
            var model = service.GetCompanies();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateCompanyService();

            if (service.CreateCompany(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateCompanyService();
            var detail = svc.GetCompanyByID(iD);

            var model = new CompanyEdit
            {
                CompanyID = detail.CompanyID,
                CompanyName = detail.CompanyName,
                Location = detail.Location,
                Price = detail.Price,
                Policy = detail.Policy
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompanyID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateCompanyService();

            if (svc.UpdateCompany(model))
            {
                TempData["SaveResult"] = "Your Provider was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Provider could not be permitted.");
            return View();
        }

        
        public ActionResult Delete(int iD)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateCompanyService();

            svc.DeleteCompany(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}