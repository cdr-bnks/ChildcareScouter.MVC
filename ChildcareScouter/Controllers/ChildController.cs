using ChildcareScouter.Models.ChildModel;
using ChildcareScouter.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class ChildController : Controller
    {
        private ChildService CreateChildService()
        {
            var svc = new ChildService();
            return svc;
        }

        public ActionResult Index()
        {
            var svc = new ChildService();
            var model = svc.GetChildren();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ChildCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var svc = CreateChildService();

            if (svc.CreateChild(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateChildService();
            var model = svc.GetChildByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateChildService();
            var detail = svc.GetChildByID(iD);

            var model = new ChildEdit
            {
                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, ChildEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ChildID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateChildService();

            if (svc.UpdateChild(model))
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
            var svc = CreateChildService();
            var model = svc.GetChildByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateChildService();

            svc.DeleteChild(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}