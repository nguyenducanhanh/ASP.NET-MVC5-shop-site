using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models.Map;
using BAITAPLON.Models;


namespace BAITAPLON.Areas.Admin.Controllers
{
    public class TrangSanPhamController : Controller
    {

     
        // GET: Admin/TrangSanPham
        public ActionResult DanhSach()
        {
           

                var map = new mapSanPham();
                return View(map.DanhSach());
            
        }

        public ActionResult ThemMoi()
        {
           
            return View(new SanPham());
        }

        [HttpPost]
        public ActionResult ThemMoi(SanPham model, HttpPostedFileBase file)
        {
           
           
            if (file.ContentLength > 0)
            {
                string thuMuc = "/Data/TinTuc/";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.HinhAnh = thuMuc + name;
            }
          


            var map = new mapSanPham();
            if(map.ThemMoi(model)>0)
            { return RedirectToAction("DanhSach");
            }
            else
            {
                ModelState.AddModelError("", map.message);
                return View(model);
            }
        
}

        public ActionResult CapNhat( int ID)
        {
            var map = new mapSanPham();
            return View(map.ChiTiet(ID));
        }

        [HttpPost]
        public ActionResult CapNhat(SanPham model, HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                string thuMuc = "/Data/TinTuc/";
                string name = file.FileName;
                var fullPath = Server.MapPath(thuMuc) + name;
                file.SaveAs(fullPath);
                model.HinhAnh = thuMuc + name;
            }

            var map = new mapSanPham();
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
            var map = new mapSanPham();
            map.Xoa(id);
            return RedirectToAction("DanhSach");
        }



        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";
      
            // GET: Product/Search
            public ActionResult Search(string searchQuery)
            {
                // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm
                var products =db.SanPhams.Where(p => p.TenSanPham.Contains(searchQuery)).ToList();

                // Trả về view hiển thị danh sách sản phẩm tìm kiếm được
                return View(products);
            }
        






    }
}