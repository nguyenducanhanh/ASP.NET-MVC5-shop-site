using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAITAPLON.Models;

namespace BAITAPLON.Controllers
{
    public class GioHangController : Controller
    {
         QuanLySanPhamEntities _db = new QuanLySanPhamEntities();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null )
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;

        }
        // GET: ADD Gio Hang
        public ActionResult AddtoCart(int id)
        {
            var pro = _db.SanPhams.SingleOrDefault(s => s.ID == id);
            if( pro!=null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "GioHang");
        }
        // trang gio hang 
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "GioHang");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro =int.Parse( form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "GioHang"); 

        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
          
            cart.Renove_CartItem(id);
            return RedirectToAction("ShowToCart", "GioHang");

        }

    }
}