using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BAITAPLON.Models.Map;

namespace BAITAPLON.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult LienHe()
        {
            var map = new mapLienHe();
            return View(map.DanhSach());
        }

        public ActionResult GioiThieu()
        {
            return View();
        }
    }
}