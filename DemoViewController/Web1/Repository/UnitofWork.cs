using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo1.Models;

namespace Webdemo1.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DataContext _dataContext;

        private IBaseService<Categories> _categoryBaseService;
        private IBaseService<Products> _productBaseService;
        public UnitofWork(DataContext dataContext) => _dataContext = dataContext;

        public IBaseService<Categories> CategoryBaseService => _categoryBaseService =
                    _categoryBaseService ?? new BaseService<Categories>(_dataContext);

        public IBaseService<Products> ProductBaseService => _productBaseService =
                    _productBaseService ?? new BaseService<Products>(_dataContext);

        /// <summary>
        /// save change
        /// </summary>
        public void Save() => _dataContext.SaveChanges();

        /// <summary>
        /// save change async
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync() => await _dataContext.SaveChangesAsync();
    }
}
