using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models;
using BAITAPLON.Models.Map;
namespace BAITAPLON.Controllers
{
    public class HomeController : Controller
    {
        // GET: TrangChu
     


        public ActionResult Home()
        {

            return View();

        }




        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        public ActionResult siu()
        {
            var oo = db.LienHes;

            return PartialView(oo);
        }



    }
}