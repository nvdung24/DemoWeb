using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo1.Models;
using Webdemo1.Repository;

namespace Web1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUnitofWork _uniofWork;

        public ProductsController(IUnitofWork unitofWork)
        {
            _uniofWork = unitofWork;
        }
        public IActionResult Index()
        {
            var products = _uniofWork.ProductBaseService.ObjectContext.Include(s => s.Category).AsEnumerable();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create(int ID)
        {
            if (ID == 0)
            {
                return View();
            }
            else
            {
                var product = _uniofWork.ProductBaseService.GetById(ID);
                return View(product);
            }

        }
        [HttpPost]
        public IActionResult Create(Products Product)
        {
            if (string.IsNullOrEmpty(Product.Name))
            {
                ModelState.AddModelError(string.Empty, "Khong duoc de trong");
                return View();
            }
            else
            {
                if (Product.ID == 0)
                {
                    _uniofWork.ProductBaseService.Add(Product);
                }
                else
                {
                    _uniofWork.ProductBaseService.Update(Product);
                }
                _uniofWork.Save();
                return RedirectToAction("Index", "Products");
            }

        }
        public IActionResult Details(int ID)
        {
            var product_detail = _uniofWork.ProductBaseService.GetById(ID);
            return View(product_detail);
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Delete(int ID)
        {
            var product_delete = _uniofWork.ProductBaseService.GetById(ID);
            _uniofWork.ProductBaseService.Delete(product_delete);
            _uniofWork.Save();
            return RedirectToAction("Index", "Products");
        }
    }
}
