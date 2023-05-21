using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAITAPLON.Models;
namespace BAITAPLON.Models.Map
{
    public class mapSanPham
    {
        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        // ham danh sach

        public List<SanPham> DanhSach()
        {
            try
            {
                return db.SanPhams.ToList();
            }
            catch
            {
                return new List<SanPham>();
            }
        }




        //chi tiet

        public SanPham ChiTiet( int id)
        {
            try
            {
                return db.SanPhams.Find(id);
            }
            catch
            {
                return new SanPham();
            }
        }

        // ADD
        public int ThemMoi(SanPham model)
        {
            if(string.IsNullOrEmpty(model.TenSanPham)==true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                db.SanPhams.Add(model);
                db.SaveChanges();
                return model.ID;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }

        //update
        public int CapNhat(SanPham model)
        {
            var update = db.SanPhams.Find(model.ID);
            if(update==null)
            {
                message = "khong tim thay ";
                return 0;
            }
            if (string.IsNullOrEmpty(model.TenSanPham) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                update.GiaBanMoi = model.GiaBanMoi;
                update.GiaBanCu = model.GiaBanCu;
                update.TenSanPham = model.TenSanPham;
                update.TomTat = model.TomTat;
                update.BaiViet = model.BaiViet;
                update.HinhAnh = model.HinhAnh;
                update.idHang = model.idHang;
                db.SaveChanges();
                return model.ID;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }


        //delete
        public bool Xoa(int ID)
        {
            var update = db.SanPhams.Find(ID);
            if (update == null)
            {
                message = "khong tim thay ";
                return false;
            }
            try
            {
                db.SanPhams.Remove(update);
                db.SaveChanges();
                return true;
            }
            catch
            {
                message = "loi he thong ";
                return false;
            }
        }







        // ham danh sâch theo hang san xuat 
        public List<SanPham> DanhSachHangSanXuat(int? idHang)
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var data = (from HangSanXuat in db.SanPhams
                        where HangSanXuat.ID == idHang
                        select HangSanXuat
                        ).ToList();
            return data;
        }

        // lung tung 
        public SanPham ChiTietHang(int id)
        {
            try
            {
                return db.SanPhams.Find(id);
            }
            catch
            {
                return new SanPham();
            }
        }

        // san pham gia re 

        public List<SanPham> SanPhamGiaRe()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var data = (from item in db.SanPhams
                        orderby item.GiaBanMoi ascending   //  ascending : giá bán mới sẽ tăng dần ;  orderby : đặt bởi 
                        select item
                        ).ToList().Take(6).ToList();
            return data;
        }

        // san pham noi bat 


        public List<SanPham> SanPhamNB()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var data = (from item in db.SanPhams
                        orderby item.GiaBanMoi descending
                        select item
                        ).ToList().Take(4).ToList();
            return data;
        }


        public List<SanPham> SanPhamChup()
        {
            QuanLySanPhamEntities db = new QuanLySanPhamEntities();
            var data = (from item in db.SanPhams
                        orderby item.TenSanPham   
                        select item
                        ).ToList().Take(3).ToList();
            return data;
        }
    }
}