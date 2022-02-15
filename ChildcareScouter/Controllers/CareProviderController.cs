using ChildcareScouter.Models.CareproviderModel;
using ChildcareScouter.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class CareproviderController : Controller
    {
        private CareproviderService CreateCareporviderService()
        {
            var svc = new CareproviderService();
            return svc;
        }

        public ActionResult Index()
        {
           var svc = new CareproviderService();
            var model = svc.GetCareprovider();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CareproviderCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var svc = CreateCareporviderService();

            if (svc.CreateCareprovider(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateCareporviderService();
            var model = svc.GetCareproviderByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateCareporviderService();
            var detail = svc.GetCareproviderByID(iD);

            var model = new CareproviderEdit
            {
                CareproviderID = detail.CareproviderID,
                ProviderName = detail.ProviderName,
                ProviderTitle = detail.ProviderTitle,
                ContactInfo = detail.ContactInfo,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, CareproviderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.CareproviderID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateCareporviderService();

            if (svc.UpdateCareprovider(model))
            {
                TempData["SaveResult"] = "Your Provider was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Provider could not be permitted.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete( int iD)
        {
            var svc = CreateCareporviderService();
            var model = svc.GetCareproviderByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost (int iD)
        {
            var svc = CreateCareporviderService();

            svc.DeleteCareprovider(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}