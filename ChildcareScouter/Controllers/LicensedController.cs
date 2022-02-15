using ChildcareScouter.Models.LicensedModel;
using ChildcareScouter.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class LicensedController : Controller
    {
        private LicensedService CreateLicenseService()
        {
            var svc = new LicensedService();
            return svc;
        }

        public ActionResult Index()
        {
            var svc = new LicensedService();
            var model = svc.GetLicenses();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LicensedCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var svc = CreateLicenseService();

            if (svc.CreateLicense(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateLicenseService();
            var model = svc.GetLicenseByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateLicenseService();
            var detail = svc.GetLicenseByID(iD);

            var model = new LicensedEdit
            {

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, LicensedEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LicensedID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateLicenseService();

            if (svc.UpdateLicense(model))
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
            var svc = CreateLicenseService();
            var model = svc.GetLicenseByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateLicenseService();

            svc.DeleteLicense(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}