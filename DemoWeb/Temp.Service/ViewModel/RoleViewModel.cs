using System;
using System.Collections.Generic;
using System.Text;
using Temp.DataAccess.Data;

namespace Temp.Service.ViewModel
{
    public class RoleViewModel
    {
        /// <summary>
        /// primary key role
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// name of role
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List user
        /// </summary>
        public ICollection<User> User { get; set; }
    }
}
