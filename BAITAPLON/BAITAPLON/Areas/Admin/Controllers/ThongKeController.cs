using BAITAPLON.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAITAPLON.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult tksp()
        {
            connect("select IDSanPham,TenSanPham,SUM(SoLuong) as SL from CTDonHang,SanPham where CTDonHang.IDSanPham=SanPham.ID group by IDSanPham,TenSanPham", 0);
            tk.ktk = 0;
            return RedirectToAction("Index");
        }
        public ActionResult tkdt()
        {
            connect("select IDDonHang,SUM(DonGia) as TT from CTDonHang group by IDDonHang",1);
            tk.ktk = 1;
            return RedirectToAction("Index");
        }
        void connect(string sql,int x)
        {
            string connectionString = @"Data Source=DESKTOP-O8KNIJL;Initial Catalog=QuanLySanPham;User ID=sa;Password=1234$;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                iddh.ct.Clear();
                string sqlQuery = sql;
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (x==0)
                    {
                        tk.tksp.Clear();
                        while (reader.Read())
                        {
                            // Lấy giá trị từ các cột dữ liệu
                            int idsp = (int)reader["IDSanPham"];
                            string ten = (string)reader["TenSanPham"];
                            int slsp = (int)reader["SL"];
                            tksp tke = new tksp { id = idsp,tensp=ten, sl = slsp };
                            tk.tksp.Add(tke);
                        }
                    }
                    else
                    {
                        tk.tkdt.Clear();
                      //  tk.dt = 0;
                        while (reader.Read())
                        {
                            // Lấy giá trị từ các cột dữ liệu
                            int idsp = (int)reader["IDDonHang"];
                            Decimal dongia = (Decimal)reader["TT"];
                            tkdt tke = new tkdt { id = idsp, gia = dongia };
                            tk.tkdt.Add(tke);
                        }
                    }
                }
            }
        }
    }
}