using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models.Map;
namespace BAITAPLON.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult TinTuc()
        {
            var map = new mapTinTuc();
            return View(map.DanhSach());
        }

       
    }
}