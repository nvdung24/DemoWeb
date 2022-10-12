using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.ViewModel;
using System.Linq;

namespace Temp.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;

        }
        public IEnumerable<RoleViewModel> GetAllRole()
        {
            var roles = _unitofWork.RoleBaseService.GetAll();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(roles);
        }
        public RoleViewModel GetIdRole(int Id)
        {
            var role = _unitofWork.RoleBaseService.GetById(Id);
            return _mapper.Map<Role, RoleViewModel>(role);
        }
        public void Save(RoleViewModel roleViewModel)
        {           
            if (roleViewModel.Id <= 0)
            {
                var role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
                _unitofWork.RoleBaseService.Add(role);
                _unitofWork.Save();
            }
            else
            {
                var role = _mapper.Map<RoleViewModel, Role>(roleViewModel);
                _unitofWork.RoleBaseService.Update(role);
                _unitofWork.Save();
            }
        }
        public void Delete(int Id)
        {
            var role_delete = _unitofWork.RoleBaseService.GetById(Id);
            _unitofWork.RoleBaseService.Delete(role_delete);
            _unitofWork.Save();
        }

        public bool CheckExist(RoleViewModel roleViewModel)
        {

            var number = _unitofWork.RoleBaseService.ObjectContext.Where(s => s.Name.ToUpper().Equals(roleViewModel.Name.ToUpper())).Count();
            if (number <= 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Role> GetListRole()
        {
            var roles = _unitofWork.RoleBaseService.GetAll();
            return roles;
        }
    }
}
