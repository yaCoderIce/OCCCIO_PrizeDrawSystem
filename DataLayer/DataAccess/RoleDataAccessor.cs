using PrizeDraw.DataLayer.Model.Identity;
using PrizeDraw.DataLayer.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrizeDraw.DataLayer.DataAccess
{
    public class RoleDataAccessor
    {
        private RoleProvider _roleProvider;
        /// <summary>
        /// RoleDataAccessor - create new role
        /// </summary>
        /// <param name="context">Input role</param>
        public RoleDataAccessor(PrizeDrawDatabaseContext context)
        {
            _roleProvider = new RoleProvider(context);
        }
        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns>List, of all roles</returns>
        public IList<Role> Get()
        {
            return _roleProvider.Get();
        }
        /// <summary>
        /// Get user role of a specific user name
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns>Role, of that user name</returns>
        public Role GetByName(string name)
        {
            return _roleProvider.GetRoleBy(name);
        }
        /// <summary>
        /// Remove User Role
        /// </summary>
        /// <param name="userId">user id</param>
        public void ClearUserRoles(int userId)
        {
            _roleProvider.ClearUserRoles(userId);

            _roleProvider.Save();
        }
    }
}
