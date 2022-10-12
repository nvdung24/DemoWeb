using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitofWork _unitofwork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofwork = unitofWork;
            _mapper = mapper;
        }
        public IEnumerable<CategoryViewModel> GetAllCategory()
        {
            var categories = _unitofwork.CategoryBaseService.GetAll();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
        }
    }
}
