using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sportmanagement.Models;
using System.Data;
using System.Data.SqlClient;
namespace Sportmanagement.Controllers
{
    public class AdminController : Controller
    {
        ConnectionManager db = new ConnectionManager();
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult View_Registration()
        {
            return View();
        }
        public ActionResult View_ContactUs()
        {
            return View();
        }
        public ActionResult Addnotification()
        {
            return View();
        }
        public ActionResult Changepassword()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            return View();
        }
        public ActionResult Aupdate(string up)
        {
            try
            {
                string query = "select * from tbl_registration where email='" + up + "'";
                DataTable dt = db.DisplayAllData(query);
                if(dt.Rows.Count>0)
                {
                    ViewBag.name = dt.Rows[0]["name"];
                    ViewBag.email = dt.Rows[0]["email"];
                    ViewBag.fname = dt.Rows[0]["fname"];
                    ViewBag.mob = dt.Rows[0]["mobile"];
                    ViewBag.branch = dt.Rows[0]["branch"];
                }
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Aupdate(string txtname,string txtfname,string txtemail,string txtmob,string txtbranch)
        {
            try
            {
                string query = "update tbl_registration set name='" + txtname + "',fname='" + txtfname + "',mobile='" + txtmob + "',branch='" + txtbranch + "' where email='" + txtemail + "'";
                if (db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record updated');window.location.href='/Admin/View_Registration'</script>");
                else
                    Response.Write("<script>alert('Record not updated');window.location.href='/Admin/View_Registration'</script>");
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        public ActionResult Adelete(string del)
        {
            try
            {
                string query = "delete from tbl_registration where email='" + del + "'";
                if(db.MyInsertUpdateDelete(query))
                    Response.Write("<script>alert('Record Deleted');window.location.href='/Admin/View_Registration'</script>");
                else
                    Response.Write("<script>alert('Server Error');window.location.href='/Admin/View_Registration'</script>");
            }
            catch(Exception ex)
            {

            }
            return View();
        }

    }
}






















