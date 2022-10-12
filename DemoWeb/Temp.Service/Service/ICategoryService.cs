using System;
using System.Collections.Generic;
using System.Text;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAllCategory();
    }
}
