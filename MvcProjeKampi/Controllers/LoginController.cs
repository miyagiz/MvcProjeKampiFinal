using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        AdminManager am = new AdminManager(new EfAdminDal());


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HomePage", "Home");
        }

        public PartialViewResult AdminLoginPartial()
        {
            return PartialView();
        }

        public ActionResult AdminLogin(Admin p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));

            var adminUserInfo = am.AdminUsernameAndPass(p.AdminUserName, result);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.errorMessage = "Kullanıcı Adı Veya Şifreniz Hatalıdır.";
                return RedirectToAction("HomePage","Home");
                //return RedirectToAction("Index");
            }
        }





    }
}