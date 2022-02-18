using ChildcareScouter.Data;
using ChildcareScouter.Data.Entities;
using ChildcareScouter.Models.CareproviderModel;
using ChildcareScouter.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class CareproviderController : Controller
    {
        private CareproviderService CreateCareporviderService( )
        {
            var userID =  Guid.Parse(User.Identity.GetUserId());
            var svc = new CareproviderService(userID );
            return svc;
        }

        public ActionResult Index( )
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new CareproviderService(userID);
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
        public ActionResult EditProviderIDAndChildID(int providerID, int childID, Careprovider model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model == null && model.CareproviderID != providerID)
            {
                ModelState.AddModelError("", "ID# does match and does not exist");
                return View(model);
            }
            var svc = CreateCareporviderService();
            
            if (!svc.AddChildToCareprovider(providerID, childID))
            {
               
            }
            ModelState.AddModelError("", "Your implementation could not be permitted");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, CareproviderEdit model, int provID , int childID)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CareproviderID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateCareporviderService();

            if (svc.UpdateCareprovider(model) && svc.AddChildToCareprovider(provID, childID))
            {
                TempData["SaveResult"] = "Your Provider was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Provider and child could not be permitted.");
            return View();
        }


        public ActionResult Delete(int iD)
        {
            var svc = CreateCareporviderService();
            var model = svc.GetCareproviderByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateCareporviderService();

            svc.DeleteCareprovider(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}