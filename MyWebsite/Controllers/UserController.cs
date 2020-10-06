using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public void Security()
        {
            string id = Session["uid"] + "";
            if (id != null && id != "")
            {
                ViewBag.show = id;
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            Security();
            return View();
        }
        [HttpGet]
        public ActionResult Profile()
        {
            Security();
            return View();
        }
        [HttpGet]
        public ActionResult Records()
        {
            Security();
            return View();
        }
        [HttpGet]
        public ActionResult Feedback()
        {
            Security();
            return View();
        }
        [HttpGet]
        public ActionResult Bookings()
        {
            Security();
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            Security();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string txtoldp,string txtnewp,string txtcpass)
        {
            string id = Session["uid"] + "";
            if (txtnewp == txtcpass)
            {
                string query1 = "update Tbl_login set password='" + txtnewp + "' where loginid='" + id + "' and password='" + txtoldp + "'";
                string query2 = "update Tbl_Registration set password='" + txtnewp + "' where email='" + id + "' and password='" + txtoldp + "'";
                ConnectionManager db = new ConnectionManager();
                if (db.MyInsertUpdateDelete(query1) && db.MyInsertUpdateDelete(query2))
                {
                    Response.Write("<script>alert('Password Updated Successfully...')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Password Not Updated...')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Password and Confirm password not match...')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            string id = Session["uid"] + "";
            if (id != null || id != "")
            {
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("/Home/Login");
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }
        public JsonResult profile(string Name, string Dob, string Email, string Mobile, string City, string State, string Pincode)
        {
            string msg = "";
            string query = "UPDATE Tbl_Registration SET name='" + Name + "',dob='" + Dob + "',email='" + Email + "',mobile='" + Mobile + "',city='" + City + "',state='" + State + "',pincode='" + Pincode + "' WHERE email='" + Email + "'";
            ConnectionManager db=new ConnectionManager();
            if(db.MyInsertUpdateDelete(query))
            {
                msg="Profile updated successfully";
            }
            else
            {
                msg = "Server error";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

    }
}
