using ChildcareScouter.Data;
using ChildcareScouter.Models.ParentModel;
using ChildcareScouter.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        private ParentService CreateParentService()
        {

            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new ParentService(userID);
            return svc;
        }

        public ActionResult Index()
        {
            
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new ParentService(userID);
            var model = svc.GetParents();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ParentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var svc = CreateParentService();

            if (svc.CreateParent(model))
            {
                TempData["SaveResult"] = "Your Provider was created successfully.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Provider could not be permitted.");

            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateParentService();
            var model = svc.GetParentByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateParentService();
            var detail = svc.GetParentByID(iD);

            var model = new ParentEdit
            {
                ParentID =detail.ParentID,
                Name = detail.Name,
                DateOfBirth = detail.DateOfBirth,
                IdentifyAs = detail.IdentifyAs,
                Email = detail.Email,
                Age = detail.Age,
                PhoneNumber = detail.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, ParentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ParentID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateParentService();

            if (svc.UpdateParent(model))
            {
                TempData["SaveResult"] = "Your Provider was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Provider could not be permitted.");
            return View();
        }

        public ActionResult Delete(int iD)
        {
            var svc = CreateParentService();
            var model = svc.GetParentByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateParentService();

            svc.DeleteParent(iD);
            TempData["SaveResult"] = "The provider has been successfully deleted from the databsae.";

            return RedirectToAction("Index");
        }
    }
}