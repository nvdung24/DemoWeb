using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo1.Models;
using Webdemo1.Repository;

namespace Web1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitofWork _uniofWork;

        public CategoriesController(IUnitofWork unitofWork)
        {
            _uniofWork = unitofWork;
        }
        public IActionResult Index()
        {
            var categories = _uniofWork.CategoryBaseService.GetAll();
            return View(categories);
        }
        public IActionResult Create(int ID)
        {
            if (ID == 0)
            {
                return View();
            }
            else
            {
                var category_edit = _uniofWork.CategoryBaseService.GetById(ID);
                return View(category_edit);
            }

        }
        [HttpPost]
        public IActionResult Create(Categories Category)
        {
            if (string.IsNullOrEmpty(Category.Name))
            {
                ModelState.AddModelError(string.Empty, "Khong duoc de trong");
                return View();
            }
            else
            {
                if (Category.ID == 0)
                {
                    _uniofWork.CategoryBaseService.Add(Category);
                }
                else
                {
                    _uniofWork.CategoryBaseService.Update(Category);
                }
                _uniofWork.Save();
                return RedirectToAction("Index", "Categories");
            }

        }
        public IActionResult Details(int ID)
        {
            var Detail = _uniofWork.CategoryBaseService.GetById(ID);
            return View(Detail);
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            var category_delete = _uniofWork.CategoryBaseService.GetById(ID);
            _uniofWork.CategoryBaseService.Delete(category_delete);
            _uniofWork.Save();
            return RedirectToAction("Index", "Categories");
        }

    }

}
