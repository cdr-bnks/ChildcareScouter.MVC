using ChildcareScouter.Data;
using ChildcareScouter.Models.ReviewModel;
using ChildcareScouter.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewService CreateReviewService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new ReviewService(userID);
            return svc;
        }

        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new ReviewService(userID);
            var model = svc.GetReview();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateReviewService();

            if (svc.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Review was created successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public ActionResult Details(int iD)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewByID(iD);

            return View(model);
        }

        public ActionResult Edit(int iD)
        {
            var svc = CreateReviewService();
            var detail = svc.GetReviewByID(iD);

            var model = new ReviewEdit
            {
                ReviewID = detail.ReviewID,
                Description = detail.Description,
                Score = detail.Score,
                IsRecommended = detail.IsRecommended,
                Report = detail.Report,
                IsReported = detail.IsReported
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int iD, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewID != iD)
            {
                ModelState.AddModelError("", "ID# does not match");
                return View(model);
            }

            var svc = CreateReviewService();

            if (svc.UpdateReivew(model))
            {
                TempData["SaveResult"] = ("","Your review was successfully updatd.");
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Your rewiew could not be permitted.");
            return View();

        }

        public ActionResult Delete(int iD)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewByID(iD);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int iD)
        {
            var svc = CreateReviewService();

            svc.DeleteReview(iD);

            TempData["SaveResult"] = "The review has been successfully deleted from the database.";

            return RedirectToAction(nameof(Index));
        }

    }
}