using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Mapper
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            //view model => entities
            CreateMap<RoleViewModel, Role>();

            
            //user => Roleviewmodel
            CreateMap<Role, RoleViewModel>();
        }
    }
}
