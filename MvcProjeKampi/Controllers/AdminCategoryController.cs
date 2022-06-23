using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntitiyLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        //[Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var CategoryValues = cm.GetList();
            return View(CategoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(p);

            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            categoryvalue.CategoryStatus = false;
            cm.CategoryUpdate(categoryvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            p.CategoryStatus = true;
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult InactiveCategories()
        {
            var inactiveCategories = cm.GetInactiveCategoriesList();
            return View(inactiveCategories);
        }

        public ActionResult DoActiveCategory(int id)
        {
            var categoryValue = cm.GetById(id);
            categoryValue.CategoryStatus = true;
            cm.CategoryUpdate(categoryValue);
            return RedirectToAction("InactiveCategories");
        }

    }
}