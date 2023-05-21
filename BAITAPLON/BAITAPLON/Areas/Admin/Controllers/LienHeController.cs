using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models.Map;
using BAITAPLON.Models;
namespace BAITAPLON.Areas.Admin.Controllers
{
    public class LienHeController : Controller
    {
        // GET: Admin/LienHe

      


        public ActionResult DanhSach()
        {
            var map = new mapLienHe();
            return View(map.DanhSach());
        }



        public ActionResult ThemMoi()
        {

            return View(new LienHe());
        }

        [HttpPost]
        public ActionResult ThemMoi(LienHe model)
        {
            var map = new mapLienHe();
            if (map.ThemMoi(model) > 0)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }





        public ActionResult CapNhat(int MaLienHe)
        {
            var map = new mapLienHe();
            return View(map.ChiTiet(MaLienHe));
        }

        [HttpPost]
        public ActionResult CapNhat(LienHe model)
        {
            var map = new mapLienHe();
            if (map.CapNhat(model) > 0)
            {
                return RedirectToAction("DanhSach");
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }



        public ActionResult Xoa(int id)
        {
            var map = new mapLienHe();
            map.Xoa(id);
            return RedirectToAction("DanhSach");
        }


    }
}