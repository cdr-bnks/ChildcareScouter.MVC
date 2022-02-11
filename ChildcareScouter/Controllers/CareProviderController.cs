using ChildcareScouter.Models.CareProviderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChildcareScouter.Controllers
{
    [Authorize]
    public class CareProviderController : Controller
    {
        // GET: CareProvider
        public ActionResult Index()
        {
            var model = new CareProviderListItem[0];
            return View(model);
        }

       /* public ActionResult Create()
        {

        }*/
    }
}