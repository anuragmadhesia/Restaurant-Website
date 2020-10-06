using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using System.Data;
using System.IO;

namespace MyWebsite.Controllers
{
    public class AdminController : Controller
    {
        ConnectionManager db = new ConnectionManager();
        // GET: /Admin/
        public void Security()
        {
            string id = Session["aid"] + "";
            if (id != null && id != "")
            {
                ViewBag.show = id;
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
        }

        public ActionResult Index()
        {
            //ViewBag.showaid = Session["aid"] + "";
            Security();
            return View();
        }
        public ActionResult ChangePassword()
        {
            Security();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string txtoldp, string txtnewp, string txtcpass)
        {
            string id = Session["aid"] + "";
            if (txtnewp == txtcpass)
            {
                string query = "update Tbl_login set password='" + txtnewp + "' where loginid='" + id + "' and password='" + txtoldp + "'";
                if (db.MyInsertUpdateDelete(query))
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
        public ActionResult Feedbacks()
        {
            Security();
            return View();
        }
        public ActionResult Contacts()
        {
            Security();
            return View();
        }
        public ActionResult Booking()
        {
            Security();
            return View();
        }
        public ActionResult Menu()
        {
            Security();
            return View();
        }
        public ActionResult Menu_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Menu_add(string txtiname, string txtidesc, string txtiprice, HttpPostedFileBase fupic)
        {
            try
            {
                string path=Path.Combine(Server.MapPath("~/Content/image/"),fupic.FileName);
                fupic.SaveAs(path);
                string query = "insert into Tbl_menu values('" + txtiname + "','" + txtidesc + "','" + txtiprice + "','" + fupic.FileName + "','" + DateTime.Now.ToString() + "')";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record added');window.location.href='/Admin/Menu'</script>");
                else
                    Response.Write("<script>alert('Record not added');window.location.href='/Admin/Menu'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Menu_update(string up)
        {
            try
            {
                string query = "select * from Tbl_menu where iid='" + up + "'";
                DataTable dt = db.DisplayAllData(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.iid = dt.Rows[0]["iid"];
                    ViewBag.iname = dt.Rows[0]["iname"];
                    ViewBag.idesc = dt.Rows[0]["idesc"];
                    ViewBag.iprice = dt.Rows[0]["iprice"];
                    ViewBag.fupic = dt.Rows[0]["ipic"];
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Menu_update(string txtiid, string txtiname, string txtidesc, string txtiprice, HttpPostedFileBase fupicc)
        {
            try
            {
                string path = Path.Combine(Server.MapPath("~/Content/image/"), fupicc.FileName);
                fupicc.SaveAs(path);
                string query = "update Tbl_menu set iname='" + txtiname + "',idesc='" + txtidesc + "',iprice='" + txtiprice + "',ipic='" + fupicc.FileName + "' where iid='" + txtiid + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record updated');window.location.href='/Admin/Menu'</script>");
                else
                    Response.Write("<script>alert('Record not updated');window.location.href='/Admin/Menu'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Menu_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_menu where iid='" + del + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Menu'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Menu'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Earnings()
        {
            Security();
            return View();
        }
        public ActionResult Data_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_orders where id='" + del + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Earnings'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Earnings'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Users()
        {
            Security();
            return View();
        }
        public ActionResult Users_update(string up)
        {
            try
            {
                string query = "select * from Tbl_Registration where email='" + up + "'";
                DataTable dt = db.DisplayAllData(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.name = dt.Rows[0]["name"];
                    ViewBag.dob = dt.Rows[0]["dob"];
                    ViewBag.email = dt.Rows[0]["email"];
                    ViewBag.mobile = dt.Rows[0]["mobile"];
                    ViewBag.city = dt.Rows[0]["city"];
                    ViewBag.state = dt.Rows[0]["state"];
                    ViewBag.pincode = dt.Rows[0]["pincode"];
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Users_update(string txtname, string txtdob, string txtemail, string txtmobile, string txtcity, string txtstate, string txtpincode)
        {
            try
            {
                string query = "update Tbl_Registration set name='" + txtname + "',dob='" + txtdob + "',mobile='" + txtmobile + "',city='" + txtcity + "',state='" + txtstate + "',pincode='" + txtpincode + "' where email='" + txtemail + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record updated');window.location.href='/Admin/Users'</script>");
                else
                    Response.Write("<script>alert('Record not updated');window.location.href='/Admin/Users'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Users_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_Registration where email='" + del + "'";
                string query1 = "delete from Tbl_Login where email='" + del + "'";
                if (db.MyInsertUpdateDelete(query) && db.MyInsertUpdateDelete(query1))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Users'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Users'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Feedback_update(string up)
        {
            try
            {
                string query = "select * from Tbl_feedbacks where fno='" + up + "'";
                DataTable dt = db.DisplayAllData(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.fno = dt.Rows[0]["fno"];
                    ViewBag.name = dt.Rows[0]["name"];
                    ViewBag.email = dt.Rows[0]["email"];
                    ViewBag.rating = dt.Rows[0]["rating"];
                    ViewBag.feedback = dt.Rows[0]["feedback"];
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Feedback_update(string txtfno,string txtname, string txtemail, string ddlrating, string txtfeedback)
        {
            try
            {
                string query = "update Tbl_feedbacks set name='" + txtname + "',feedback='" + txtfeedback + "',rating='" + ddlrating + "' where fno='" + txtfno + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record updated');window.location.href='/Admin/Feedbacks'</script>");
                else
                    Response.Write("<script>alert('Record not updated');window.location.href='/Admin/Feedbacks'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Booking_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_bookings where bno='" + del + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Booking'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Booking'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Feedback_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_feedbacks where fno='" + del + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Feedbacks'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Feedbacks'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Contact_delete(string del)
        {
            try
            {
                string query = "delete from Tbl_Contacts where cno='" + del + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/Contacts'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/Contacts'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}
