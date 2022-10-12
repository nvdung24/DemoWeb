using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webdemo1.Models;

namespace Webdemo1.Repository
{
    public interface IUnitofWork
    {
        IBaseService<Categories> CategoryBaseService { get; }
        IBaseService<Products> ProductBaseService { get; }
        /// <summary>
        /// save
        /// </summary>
        void Save();

        /// <summary>
        /// save async
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}
