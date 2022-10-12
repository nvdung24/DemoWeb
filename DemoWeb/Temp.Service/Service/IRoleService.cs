using System;
using System.Collections.Generic;
using System.Text;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    public interface IRoleService
    {
       
        IEnumerable<RoleViewModel> GetAllRole();
        IEnumerable<Role> GetListRole();

        RoleViewModel GetIdRole(int Id);

        void Save(RoleViewModel roleViewModel);

        void Delete(int Id);

        bool CheckExist(RoleViewModel roleViewModel);

    }
}
