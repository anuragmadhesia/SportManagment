using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sportmanagement.Models;

namespace Sportmanagement.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        public ActionResult Index()
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
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult Complain()
        {
            return View();
        }
        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Changepassword(string txtold,string txtnew,string txtcpass)
        {
              string id = Session["uid"] + "";
              if (txtnew == txtcpass)
              {
                  string query = "update tbl_login set passwd='" + txtnew + "' where userid='" + id + "' and passwd='" + txtold + "'";
                  ConnectionManager db = new ConnectionManager();
                  if (db.MyInsertUpdateDelete(query))
                      Response.Write("<script>alert('Password update successfully')</script>");
                  else
                      Response.Write("<script>alert('Password not update ')</script>");
              }
              else
              {
                  Response.Write("<script>alert('Password and confirmpassword not match ')</script>");
              }
            return View();
        }
        public ActionResult LogOut()
        {
            string id = Session["uid"] + "";
            if(id!=null ||id!="")
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
        public JsonResult profile(string Name,string Fname,string Email,string Mobile)
        {
            string msg="";
            string query = "update tbl_registration set name='" + Name + "',fname='" + Fname + "',email='" + Email + "',mobile='" + Mobile + "' where email='" + Email + "'";
            ConnectionManager db = new ConnectionManager();
            if(db.MyInsertUpdateDelete(query))
            {
                msg = "Profile Update successfully";
            }
            else
            {
                msg = "Server error";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(string txtrate,string txtmsg)
        {
            try
            {
                string id = Session["uid"] + "";
                string query = "insert into tbl_feedback values('"+txtrate+"','"+txtmsg+"','"+id+"','"+DateTime.Now.ToString()+"')";
                ConnectionManager db=new ConnectionManager();
                if(db.MyInsertUpdateDelete(query))
                   Response.Write("<script>alert('Feedback submitted Successfully.')</script>");
                else
                    Response.Write("<script>alert('unable to save data.')</script>");
                
            }
            catch(Exception ex)
            {

            }
            return View();
        }
    }
}
