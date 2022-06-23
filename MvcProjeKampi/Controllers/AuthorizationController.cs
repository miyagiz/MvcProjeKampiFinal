using BusinessLayer.Concreate;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles = "A")]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        RoleManager rm = new RoleManager(new EfRoleDal());

        public ActionResult Index()
        {
            var adminValues = am.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in rm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.RoleName + " Rolü - " + x.Description,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.roleValue = adminRoleValue;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));

            p.AdminPassword = result;
            p.AdminStatus = true;
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in rm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.RoleName + " Rolü - " + x.Description,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.roleValue = adminRoleValue;
            var adminValue = am.GetById(id);
            adminValue.AdminPassword = "";
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));

            p.AdminPassword = result;
            p.AdminStatus = true;
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values = am.GetById(id);
            values.AdminStatus = false;
            am.AdminUpdate(values);
            return RedirectToAction("Index");
        }

        public ActionResult DeActiveAdminList()
        {
            var values = am.GetListStatusFalse();
            return View(values);
        }

        public ActionResult DoActiveAdminStatus(int id)
        {
            var values = am.GetById(id);
            values.AdminStatus = true;
            am.AdminUpdate(values);
            return RedirectToAction("DeActiveAdminList");
        }
    }
}