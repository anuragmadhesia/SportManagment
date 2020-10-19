using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Sportmanagement.Models;
using System.Data;

namespace Sportmanagement.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ConnectionManager db = new ConnectionManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            CaptchaCodeGenerator cp = new CaptchaCodeGenerator();
           string cph= cp.GetCaptch();
           ViewBag.cph = cph;
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string txtname,string txtfname,string txtemail,string ddlbranch,string txtaddress,string ddlyear,string ddlgender,string txtpassword,string txtmobile,HttpPostedFileBase fupic,string txtcph,string txtcaptcha,string ddltype,string txtcpassword)
        {
           
            if (txtpassword == txtcpassword)
            {
                if (txtcph == txtcaptcha)
                {
                    string path=Path.Combine(Server.MapPath("~/Content/img/"), fupic.FileName);
                    fupic.SaveAs(path);
                    string query = "insert into tbl_registration values('" + txtname + "','" + txtfname + "','" + txtemail + "','" + txtmobile + "','" + txtpassword + "','" + ddlbranch + "','" + ddlyear + "','" + txtaddress + "','" + ddlgender + "','" + ddltype + "','" + fupic.FileName + "','" + DateTime.Now.ToString() + "')";

                    string query2 = "insert into tbl_login values('" + txtemail + "','" + txtpassword + "','user','" + DateTime.Now.ToString() + "')";
                    if (db.MyInsertUpdateDelete(query) && db.MyInsertUpdateDelete(query2))
                        Response.Write("<script>alert('Registration save successfully..')</script>");
                    else
                        Response.Write("<script>alert('unable to save Data..')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Captcha code Not match')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Password and confirm password not match')</script>");
            }
            return View();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(string txtname,string txtemail,string txtmobile,string txtmsg)
        {
            ConnectionManager db = new ConnectionManager();
            try
            {
                string query = "insert into tbl_enquiry values('" + txtname + "','" + txtemail + "','" + txtmobile + "','" + txtmsg + "','" + DateTime.Now.ToString() + "')";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Enquiry save successfully..')</script>");
                else
                    Response.Write("<script>alert('unable to save Data..')</script>");
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtuserid,string txtpassword)
        {
            string query = "select * from tbl_login where userid='" + txtuserid + "' and passwd='" + txtpassword + "'";
           DataTable dt= db.DisplayAllData(query);
            if(dt.Rows.Count>0)
            {
                string type = dt.Rows[0][2]+"";
                if(type=="user")
                {
                    Session["uid"] = txtuserid;
                    Response.Redirect("/Student/Index");
                }
                else if(type=="admin")
                {
                    Session["aid"] = txtuserid;
                    Response.Redirect("/Admin/Index");
                }
                else
                {
                    Response.Write("<script>alert('Invalid type')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Userid or password Not match')</script>");
            }
            return View();
        }
        public ActionResult Event()
        {
            return View();

        }
        public ActionResult Gallery()
        {
            return View();

        }
        public ActionResult AboutUs()
        {
            return View();

        }
        public ActionResult UpComingEvent()
        {
            return View();

        }


    }
}
