using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models;
using BAITAPLON.Models.Map;
namespace BAITAPLON.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham


      
        public ActionResult TrangChiTietSanPham(int id)
        {
            var map = new mapSanPham();
            return View(map.ChiTiet(id));
        }

        public ActionResult TrangDanhSachSanPham()
        {
            var map = new mapSanPham();
            return View(map.DanhSach());
            
            
        }

        public ActionResult XemThemSanPham()
        {
            var map = new mapSanPham();
            return View(map.DanhSach());


        }

        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        public ActionResult DELL()
        {var oo = db.SanPhams.Where(n => n.idHang == 1).Take(4).ToList();

            return PartialView(oo);
        }


        public ActionResult samsung()
        {
            var aa = db.SanPhams.Where(n => n.idHang == 6).Take(3).ToList();

            return PartialView(aa);
        }

        public ActionResult HP()
        {
            var abc = db.SanPhams.Where(n => n.idHang == 3).Take(3).ToList();

            return PartialView(abc);
        }

        public ActionResult MAC()
        {
            var abc = db.SanPhams.Where(n => n.idHang == 2).Take(3).ToList();

            return PartialView(abc);
        }




        public ActionResult SanPhamNoiBat()
        {

            var map = new mapSanPham();
            return View(map.SanPhamNB());


        }


        public ActionResult SanPhamGiaRe()
        {
            var map = new mapSanPham();
            return View(map.SanPhamGiaRe());


        }


        public ActionResult SanPhamChup()
        {
            var map = new mapSanPham();
            return View(map.SanPhamChup());


        }


        public ActionResult DanhSachTheoLoai(int? idHang)
        {
            ViewBag.idHang = idHang;
            return View(new mapSanPham().DanhSachHangSanXuat(idHang));


        }

        public ActionResult TrangTheoHang(int idHang)
        {
            var map = new mapSanPham();
            return View(map.ChiTietHang(idHang));
        }








        // GET: Product/Search
        public ActionResult Search(string searchQuery)
        {
            // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm
            var products = db.SanPhams.Where(p => p.TenSanPham.Contains(searchQuery)).ToList();

            // Trả về view hiển thị danh sách sản phẩm tìm kiếm được
            return View(products);
        }


    }
}