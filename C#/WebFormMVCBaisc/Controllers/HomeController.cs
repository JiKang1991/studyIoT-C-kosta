using myLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCWebTest.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Coding\MVCWeb\WebDB.mdf;Integrated Security=True;Connect Timeout=30";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Login()
        {
            string userId = Request.QueryString["userId"];
            string userPw = Request.QueryString["userPw"];

            if (userId != null)
            {
                DBConnecter dBConnecter = new DBConnecter(connectionString);
                string sql = $"SELECT password FROM members WHERE id='{userId}'";
                string selectedPw = dBConnecter.Get(sql).ToString();
                string securityPw = MyLib.GetEncrypt(userPw);
                if (selectedPw == securityPw)
                {
                    // OK
                    return RedirectToAction("Index");
                }
            }

            return View();
        }        
    }
}