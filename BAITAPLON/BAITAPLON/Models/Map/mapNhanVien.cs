using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAITAPLON.Models;
namespace BAITAPLON.Models.Map
{
    public class mapNhanVien
    {
        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        // ham danh sach

        public List<NhanVien> DanhSach()
        {
            try
            {
                return db.NhanViens.ToList();
            }
            catch
            {
                return new List<NhanVien>();
            }
        }












        //chi tiet

        public NhanVien ChiTiet(int id)
        {
            try
            {
                return db.NhanViens.Find(id);
            }
            catch
            {
                return new NhanVien();
            }
        }

        // ADD
        public int ThemMoi(NhanVien model)
        {
            if (string.IsNullOrEmpty(model.TenNhanVien) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                db.NhanViens.Add(model);
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
        public int CapNhat(NhanVien model)
        {
            var update = db.NhanViens.Find(model.ID);
            if (update == null)
            {
                message = "khong tim thay ";
                return 0;
            }
            if (string.IsNullOrEmpty(model.TenNhanVien) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                update.ChucVu = model.ChucVu;
                update.DiaChi = model.DiaChi;
                update.TenNhanVien = model.TenNhanVien;
                update.SDT = model.SDT;
                update.NgaySinh = model.NgaySinh;
                update.idloaiNhanVien = model.idloaiNhanVien;
                update.Password = model.Password;
                update.Username = model.Username;
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
            var update = db.NhanViens.Find(ID);
            if (update == null)
            {
                message = "khong tim thay ";
                return false;
            }
            try
            {
                db.NhanViens.Remove(update);
                db.SaveChanges();
                return true;
            }
            catch
            {
                message = "loi he thong ";
                return false;
            }
        }





    }
}