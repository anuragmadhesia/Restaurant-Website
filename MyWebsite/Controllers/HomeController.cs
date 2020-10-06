using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite.Models;
using System.Data;
using System.Data.SqlClient;


namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        ConnectionManager db = new ConnectionManager();
        string iid, iname, idesc, iprice, fupic, s, t;
        int i;
        public void logs(){
            string id = Session["uid"] + "";
            if (id != null && id != "")
            {
                ViewBag.UserIndex = "/User/Index";
                ViewBag.UserPanel = "USER PANEL";
                ViewBag.log = "Log Out";
                ViewBag.logstyle = "btn-outline-danger";
            }
            else
            {
                ViewBag.log = "Login";
                ViewBag.logstyle = "btn-success btn-rounded";
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
            logs();
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            logs();
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            logs();
            CapthaCodeGenerator cp = new CapthaCodeGenerator();
            string cph = cp.GetCaptcha();
            ViewBag.cph = cph;
            return View();
        }
        [HttpPost]
        public ActionResult Register(string txtname, string txtdob, string txteppassword, string txtcppassword, string txtemail, string txtmobile,string txtcity,string txtstate,string txtpincode, string txtcaptha, string txtinputcaptha)
        {
            if (txteppassword == txtcppassword)
            {
                if (txtcaptha == txtinputcaptha)
                {
                    string query_register = "insert into Tbl_Registration values('" + txtname + "','" + txtdob + "','" + txteppassword + "','" + txtemail + "','" + txtmobile + "','" + txtcity + "','" + txtstate + "','" + txtpincode + "','" + DateTime.Now.ToString() + "')";
                    string query_login = "insert into Tbl_login values('" + txtemail + "','" + txteppassword + "','user','" + DateTime.Now.ToString() + "')";
                    try
                    {
                        if (db.MyInsertUpdateDelete(query_register) && db.MyInsertUpdateDelete(query_login))
                            Response.Write("<script>alert('Query Save successfully...')</script>");
                        else
                            Response.Write("<script>alert('Unable to save data...')</script>");
                        return View();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Exception Occured...')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Captcha...')</script>");
                } 
            }
            else
            {
                Response.Write("<script>alert('Password and confirm are not same...')</script>");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Reviews()
        {
            logs();
            return View();
        }
        [HttpPost]
        public ActionResult Reviews(string txtname, string txtemail, string txtrate, string txtfeedback)
        {
                string query = "insert into Tbl_feedbacks values('" + txtname + "','" + txtemail + "','" + txtrate + "','" + txtfeedback + "','" + DateTime.Now.ToString() + "')";
                try
                {
                    if (db.MyInsertUpdateDelete(query))
                        Response.Write("<script>alert('Query Save successfully...')</script>");
                    else
                        Response.Write("<script>alert('Unable to save data...')</script>");
                    return View();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Exception Occured...')</script>");
                }
            return View();
        }

        [HttpGet]
        public ActionResult Menu()
        {
            logs();
            return View();
        }
        public ActionResult Cart_add(string id)
        {
            logs();
            try
            {
                string query = "select * from Tbl_menu where iid='" + id + "'";
                DataTable dt = db.DisplayAllData(query);
                if (dt.Rows.Count > 0)
                {
                    if (Request.Cookies["aa"] != null)
                    {
                        s = Convert.ToString(Request.Cookies["aa"].Value);
                        string[] strArr = s.Split('|');
                        for (i = 0; i < strArr.Length; i++)
                        {
                            t = strArr[i].ToString();
                            string[] strArr1 = t.Split(',');
                            if (strArr1[0] == id)
                            {
                                Response.Redirect("/Home/Menu");
                            }
                        }
                    }
                    iid = dt.Rows[0]["iid"].ToString();
                    iname = dt.Rows[0]["iname"].ToString();
                    idesc = dt.Rows[0]["idesc"].ToString();
                    iprice = dt.Rows[0]["iprice"].ToString();
                    fupic = dt.Rows[0]["ipic"].ToString();
                }
                if (Request.Cookies["aa"] == null)
                {
                    Response.Cookies["aa"].Value = iid.ToString() + "," + iname.ToString() + "," + idesc.ToString() + "," + iprice.ToString() + ",1," + fupic.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + iid.ToString() + "," + iname.ToString() + "," + idesc.ToString() + "," + iprice.ToString()+ ",1," +  fupic.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(7);
                }
                Response.Redirect("/Home/Menu");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Cart_delete(string del)
        {
            try
            {
                if (Request.Cookies["aa"] != null)
                {
                    s = Convert.ToString(Request.Cookies["aa"].Value);
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                    string[] strArr = s.Split('|');
                    for (i = 0; i < strArr.Length; i++)
                    {
                        t = strArr[i].ToString();
                        string[] strArr1 = t.Split(',');
                        if (strArr1[0] != del)
                        {
                            if (Request.Cookies["bb"] == null)
                            {
                                Response.Cookies["bb"].Value = strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + strArr1[4].ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                            else
                            {
                                Response.Cookies["bb"].Value = Request.Cookies["bb"].Value + "|" + strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + strArr1[4].ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                        }
                    }
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["aa"].Value = Request.Cookies["bb"].Value;
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(7);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable to delete data... due to exception')</script>");
            }
            Response.Cookies["bb"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Home/Cart");
            return View();
        }
        [HttpGet]
        public ActionResult Cart_Edit(string ed)
        {
            try
            {
                if (Request.Cookies["aa"] != null)
                {
                    s = Convert.ToString(Request.Cookies["aa"].Value);
                    string[] strArr = s.Split('|');
                    for (i = 0; i < strArr.Length; i++)
                    {
                        t = strArr[i].ToString();
                        string[] strArr1 = t.Split(',');
                        if (strArr1[0] == ed)
                        {
                            ViewBag.icode = strArr1[0].ToString();
                            ViewBag.iname = strArr1[1].ToString();
                            ViewBag.iprice = strArr1[3].ToString();
                            ViewBag.iqty = strArr1[4].ToString();
                            ViewBag.ipic = strArr1[5].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable to delete data... due to exception')</script>");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Cart_Edit(string txtiqty,string txticode)
        {
            try
            {
                if (Request.Cookies["aa"] != null)
                {
                    s = Convert.ToString(Request.Cookies["aa"].Value);
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                    string[] strArr = s.Split('|');
                    for (i = 0; i < strArr.Length; i++)
                    {
                        t = strArr[i].ToString();
                        string[] strArr1 = t.Split(',');
                        if (strArr1[0] == txticode)
                        {
                            if (Request.Cookies["bb"] == null)
                            {
                                Response.Cookies["bb"].Value = strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + txtiqty.ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                            else
                            {
                                Response.Cookies["bb"].Value = Request.Cookies["bb"].Value + "|" + strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + txtiqty.ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                        }
                        else
                        {
                            if (Request.Cookies["bb"] == null)
                            {
                                Response.Cookies["bb"].Value = strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + strArr1[4].ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                            else
                            {
                                Response.Cookies["bb"].Value = Request.Cookies["bb"].Value + "|" + strArr1[0].ToString() + "," + strArr1[1].ToString() + "," + strArr1[2].ToString() + "," + strArr1[3].ToString() + "," + strArr1[4].ToString() + "," + strArr1[5].ToString();
                                Response.Cookies["bb"].Expires = DateTime.Now.AddDays(7);
                            }
                        }
                    }
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["aa"].Value = Request.Cookies["bb"].Value;
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(7);
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable to delete data... due to exception')</script>");
            }
            Response.Cookies["bb"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Home/Cart");
            return View();
        }
        [HttpGet]
        public ActionResult Cart_deleteAll()
        {
            try
            {
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Unable to delete data... due to exception')</script>");
            }
            Response.Redirect("/Home/Cart");
            return View();
        }
        [HttpGet]
        public ActionResult Cart()
        {
            logs();
            return View();
        }
        [HttpGet]
        public ActionResult Purchase()
        {
            string id = Session["uid"] + "";
            string price = Session["iprice"] + "";
            string iname = Session["iname"] + "";
            string icode = Session["icode"] + "";
            if (id != null && id != "")
            {
                string query = "select * from Tbl_Registration where email='" + id + "'";
                DataTable dt = db.DisplayAllData(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.iprice = price.ToString();
                    ViewBag.icode = icode.ToString();
                    ViewBag.iname = iname.ToString();
                    ViewBag.uname = dt.Rows[0]["name"].ToString();
                    ViewBag.uemail = dt.Rows[0]["email"].ToString();
                    ViewBag.umobile = dt.Rows[0]["mobile"].ToString();
                    ViewBag.address = dt.Rows[0]["city"].ToString() + "," + dt.Rows[0]["state"].ToString() + "," + dt.Rows[0]["pincode"].ToString();
                }
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Purchase(string txticode,string txtiname,string txtprice, string txtuname,string txtuemail, string txtmobile, string txtaddress,string ddlpmethod)
        {
            try
            {
                string query = "insert into Tbl_orders values('" + txticode + "','" + txtiname + "','" + txtprice + "','" + txtuemail + "','" + txtuname + "','" + txtmobile + "','" + txtaddress + "','" + ddlpmethod + "','" + DateTime.Now.ToString() + "')";
                if (db.MyInsertUpdateDelete(query))
                {
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                    Session.Remove("icode");
                    Session.Remove("iname");
                    Session.Remove("iprice");
                    Response.Write("<script>alert('Purchased');window.location.href='/Home/Cart'</script>");
                }
                else
                    Response.Write("<script>alert('Not Purchased');window.location.href='/Home/Cart'</script>");
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Gallery()
        {
            logs();
            return View();
        }
        [HttpGet]
        public ActionResult Booking()
        {
            logs();
            CapthaCodeGenerator cp = new CapthaCodeGenerator();
            string cph= cp.GetCaptcha();
            ViewBag.cph = cph;
            return View();
        }     
        [HttpPost]
        public ActionResult Booking(string txtname, string txtmobile, string txtemail, string txtdate, string txttime, string ddltabletype, string ddlpreference, string txtcaptha, string txtinputcaptha)
        {
            if (txtcaptha == txtinputcaptha)
            {
                string query = "insert into Tbl_Bookings values('" + txtname + "','" + txtmobile + "','" + txtemail + "','" + txtdate + "','" + txttime + "','" + ddltabletype + "','" + ddlpreference + "','" + DateTime.Now.ToString() + "')";
                try
                {
                    if (db.MyInsertUpdateDelete(query))
                        Response.Write("<script>alert('Query Save successfully...')</script>");
                    else
                        Response.Write("<script>alert('Unable to save data...')</script>");
                    return View();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Exception Occured...')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Incorrect Captcha...')</script>");
            }            
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            logs();
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string txtname, string txtemail, string txtmsg)
        {
            string query = "insert into Tbl_Contacts values('" + txtname + "','" + txtemail + "','" + txtmsg + "','" + DateTime.Now.ToString() + "')";
            try
            {
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Query Save successfully...')</script>");
                else
                    Response.Write("<script>alert('Unable to save data...')</script>");
                return View();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception Occured...')</script>");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            string id = Session["uid"] + "";
            if (id != null && id != "")
            {
                Response.Redirect("/User/Logout");
                ViewBag.log = "Log Out";
                ViewBag.logstyle = "btn-outline-danger";
            }
            else
            {
                ViewBag.log = "Login";
                ViewBag.logstyle = "btn-success btn-rounded";
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtuserid,string txtpassword)
        {
            string query = "select * from Tbl_Login where loginid='" + txtuserid + "' and password='" + txtpassword + "'";
            DataTable dt = db.DisplayAllData(query);
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0][2] + "";
                if (type == "user")
                {
                    Session["uid"] = txtuserid;
                    Response.Redirect("/User/Index");
                }
                else if (type == "admin")
                {
                    Session["aid"] = txtuserid;
                    Response.Redirect("/Admin/Index");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Type')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Login ID or Password Not Match')</script>");
            }
            return View();
        }

    }
}
