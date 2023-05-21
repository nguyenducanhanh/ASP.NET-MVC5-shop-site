using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAITAPLON.Models;
namespace BAITAPLON.Models.Map
{
    public class mapLienHe
    {


        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        // ham danh sach

        public List<LienHe> DanhSach()
        {
            try
            {
                return db.LienHes.ToList();
            }
            catch
            {
                return new List<LienHe>();
            }
        }
        //chi tiet
        public LienHe ChiTiet(int MaLienHe)
        {
            try
            {
                return db.LienHes.Find(MaLienHe);
            }
            catch
            {
                return new LienHe();
            }
        }


        // ADD
        public int ThemMoi(LienHe model)
        {
            if (string.IsNullOrEmpty(model.HoTen) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                db.LienHes.Add(model);
                db.SaveChanges();
                return model.MaLienHe;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }
        //update
        public int CapNhat(LienHe model)
        {
            var update = db.LienHes.Find(model.MaLienHe);
            if (update == null)
            {
                message = "khong tim thay ";
                return 0;
            }
            if (string.IsNullOrEmpty(model.HoTen) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                update.HoTen = model.HoTen;
                update.SDT = model.SDT;
                update.Email = model.Email;
              
                db.SaveChanges();
                return model.MaLienHe;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }


        


        //delete
        public bool Xoa(int MaLienHe)
        {
            var update = db.LienHes.Find(MaLienHe);
            if (update == null)
            {
                message = "khong tim thay ";
                return false;
            }
            try
            {
                db.LienHes.Remove(update);
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