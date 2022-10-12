using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Temp.Common.Infrastructure;
using Temp.Service.Service;
using Temp.Service.ViewModel;
using System.Linq;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// User controller 
    /// </summary>
    [Authorize(Policy = Constants.Role.Admin)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        /// <summary>
        /// usercontroller constructor
        /// </summary>
        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        
        /// <summary>
        /// list user view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var users = _userService.GetAllIncluding();
            return View(users);
        }
        
        /// <summary>
        /// button for request approve
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ApproveRequest(int id)
        {
           var user = _userService.GetById(id);
            _userService.ApproveRequestExpired(user);
            return RedirectToAction("Index", "User");
        }
        
        /// <summary>
        /// button for request reject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RejectRequest(int id)
        {
            var user = _userService.GetById(id);
            _userService.RejectRequestExpired(user);
            return RedirectToAction("Index", "User");
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Save(int Id)
        {
            var roles = _roleService.GetListRole().ToList();
            var users = new CreateUserViewModel { Roles = roles };
            if (Id <= 0)
            {
                users.Roles = roles;
            }
            else
            {
                var user_edit = _userService.GetUserEditById(Id);
                user_edit.Roles = roles;
            }
            return View(users);
        }
        [HttpPost]
        public IActionResult Save(CreateUserViewModel userDto)
        {
            _userService.Save(userDto);
            return RedirectToAction("Index", "User");
        }
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index", "User");
        }
        
    }
}