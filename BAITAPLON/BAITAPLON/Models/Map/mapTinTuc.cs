using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAITAPLON.Models;
namespace BAITAPLON.Models.Map
{
    public class mapTinTuc
    {
        public QuanLySanPhamEntities db = new QuanLySanPhamEntities();
        public string message = "";

        // ham danh sach

        public List<TinTuc> DanhSach()
        {
            try
            {
                return db.TinTucs.ToList();
            }
            catch
            {
                return new List<TinTuc>();
            }
        }












        //chi tiet

        public TinTuc ChiTiet(int MaTin)
        {
            try
            {
                return db.TinTucs.Find(MaTin);
            }
            catch
            {
                return new TinTuc();
            }
        }

        // ADD
        public int ThemMoi(TinTuc model)
        {
            if (string.IsNullOrEmpty(model.TieuDe) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                db.TinTucs.Add(model);
                db.SaveChanges();
                return model.MaTin;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }

        //update
        public int CapNhat(TinTuc model)
        {
            var update = db.TinTucs.Find(model.MaTin);
            if (update == null)
            {
                message = "khong tim thay ";
                return 0;
            }
            if (string.IsNullOrEmpty(model.TieuDe) == true)
            {
                message = "nhap thieu ten trang";
                return 0;
            }
            try
            {
                update.TieuDe = model.TieuDe;
                update.TomTat = model.TomTat;
                update.NoiDung = model.NoiDung;
                update.TacGia = model.TacGia;
                update.NgayDangTin = model.NgayDangTin;
                update.HinhAnh = model.HinhAnh;
                
                db.SaveChanges();
                return model.MaTin;
            }
            catch
            {
                message = "loi he thong ";
                return 0;
            }

        }


        //delete
        public bool Xoa(int MaTin)
        {
            var update = db.TinTucs.Find(MaTin);
            if (update == null)
            {
                message = "khong tim thay ";
                return false;
            }
            try
            {
                db.TinTucs.Remove(update);
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