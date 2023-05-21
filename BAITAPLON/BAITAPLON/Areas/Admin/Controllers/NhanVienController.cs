using BAITAPLON.Models;
using BAITAPLON.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAITAPLON.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: Admin/NhanVien

        public bool KiemTraChucNang(int idChucNang)
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            NhanVien nvSession = (NhanVien)Session["user"];                // trong cai tk admin khi da dang nhap thi 
            var count = db.PhanQuyens.Count(m => m.idNhanVien == nvSession.ID & m.idChucNang == idChucNang);  // ktra xem co quyen nay khong bang cach xem trong bang PhanQuyen 
            if (count == 0)
            {
                // báo ko có quyền 
                return false;
            }
            else
            {
                return true;
            }
        }
        public ActionResult DanhSach()
        {
            if (KiemTraChucNang(1) == false)                 // neu id la  1 thi khong duoc return dong 34  
            {
                return Redirect("/Admin/BaoLoi/KhongCoQuyen");
            }

            var map = new mapNhanVien();
            return View(map.DanhSach());
        }



        public ActionResult ThemMoi()
        {
            if (KiemTraChucNang(1) == false)
            {
                return Redirect("/Admin/BaoLoi/KhongCoQuyen");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVien model, HttpPostedFileBase file)
        {




            var map = new mapNhanVien();
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

        // update

        public ActionResult CapNhat(int ID)
        {
            if (KiemTraChucNang(1) == false)
            {
                return Redirect("/Admin/BaoLoi/KhongCoQuyen");
            }
            var map = new mapNhanVien();
            return View(map.ChiTiet(ID));
        }



        [HttpPost]
        public ActionResult CapNhat(NhanVien model, HttpPostedFileBase file)
        {

            var map = new mapNhanVien();
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



        // delete

        public ActionResult Xoa(int id)
        {
            if (KiemTraChucNang(1) == false)
            {
                return Redirect("/Admin/BaoLoi/KhongCoQuyen");
            }
            var map = new mapNhanVien();
            map.Xoa(id);
            return RedirectToAction("DanhSach");
        }


        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        // GET: Product/Search
        public ActionResult Search(string searchQuery)
        {
            // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm
            var products = db.NhanViens.Where(p => p.TenNhanVien.Contains(searchQuery)).ToList();

            // Trả về view hiển thị danh sách sản phẩm tìm kiếm được
            return View(products);
        }



    }
}