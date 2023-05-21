using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models.Map;
using BAITAPLON.Models;


namespace BAITAPLON.Areas.Admin.Controllers
{
    public class TrangTinTucController : Controller
    {

        // GET: Admin/TrangSanPham
        public ActionResult DanhSach()
        {
            var map = new mapTinTuc();
            return View(map.DanhSach());
        }

        public ActionResult ThemMoi()
        {

            return View(new TinTuc());
        }

        [HttpPost]
        public ActionResult ThemMoi(TinTuc model, HttpPostedFileBase file)
        {
            
            
            if (file.ContentLength > 0)
            {
                string thuMuc = "/Data/TinTuc/";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.HinhAnh = thuMuc + name;
            }
            


            var map = new mapTinTuc();
            if (map.ThemMoi(model) > 0)
            {
                return RedirectToAction("DanhSach");          // DanhSach
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }

        }
        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public ActionResult CapNhat(int MaTin)
        {

            var map = new mapTinTuc();
            return View(map.ChiTiet(MaTin));
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult CapNhat(TinTuc model, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string thuMuc = "/Data/TinTuc/";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.HinhAnh = thuMuc + name;
            }
            var update = db.TinTucs.Find(model.MaTin);
            var map = new mapTinTuc();
            if (map.CapNhat(model) > 0)
            {
                return RedirectToAction("DanhSach");              // DanhSach
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        }

        public ActionResult Xoa(int MaTin)
        {
            var map = new mapTinTuc();
            map.Xoa(MaTin);
            return RedirectToAction("DanhSach");
        }









    }
}