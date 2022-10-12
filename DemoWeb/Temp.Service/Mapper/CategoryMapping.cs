using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Mapper
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Category, CategoryViewModel>();
        }
    }
}
