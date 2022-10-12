using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temp.Common.Infrastructure;
using Temp.Service.BaseService;
using Temp.Service.Service;
using Temp.Service.ViewModel;

namespace Temp.Web.Controllers
{
    [Authorize(Policy = Constants.Role.Admin)]
    public class RoleController : Controller
    {
       
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            var roles = _roleService.GetAllRole();
            return View(roles);
        }
        [HttpGet]
        public IActionResult Save(int Id)
        {
            if (Id <= 0)
            {
                return View();
            }
            else
            {
                var role_edit = _roleService.GetIdRole(Id);
                return View(role_edit);
            }
        }

        [HttpPost]
        public IActionResult Save(RoleViewModel roleViewModel)
        {
            if (string.IsNullOrEmpty(roleViewModel.Name))
            {
                ModelState.AddModelError(string.Empty, "Khong duoc de trong");
                return View();
            }
            else if(roleViewModel.Name.Length<3 || roleViewModel.Name.Length>50){
                ModelState.AddModelError(string.Empty, "Khong ko hop le");
                return View();
            }
            
            else
            {
                if (_roleService.CheckExist(roleViewModel))
                {
                    _roleService.Save(roleViewModel);
                    return RedirectToAction("Index", "Role");
                }
                //them moi else trar message trung
                //_roleService.Save(roleViewModel);   
                //return RedirectToAction("Index", "Role");
                else
                {
                    ModelState.AddModelError(string.Empty, "Name da bi trung");
                    return View();
                }
            }
            
        }
         [HttpGet]
         [HttpPost]
        public IActionResult Delete(int id)
        {
            _roleService.Delete(id);
            return RedirectToAction("Index", "Role");
        }
    }
}
