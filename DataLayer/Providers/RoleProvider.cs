using System;
using System.Collections.Generic;
using System.Linq;
using PrizeDraw.DataLayer.Model.Identity;
using Microsoft.EntityFrameworkCore;

namespace PrizeDraw.DataLayer.Providers
{
    public class RoleProvider : Provider
    {
        public RoleProvider(string connectionString) : base(connectionString)
        {
        }

        public RoleProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }
        /// <summary>
        /// GetRoleBy - get role by name
        /// </summary>
        /// <param name="roleName">input role name</param>
        /// <returns>Role of that name</returns>
        public Role GetRoleBy(string roleName)
        {
            return (from r in DatabaseContext.Roles.Include(ur => ur.UserRoles)
                    where r.Name == roleName
                    select r).First();
        }
        /// <summary>
        /// Get - get list of roles
        /// </summary>
        /// <returns>list of roles</returns>
        public IList<Role> Get()
        {
            return DatabaseContext.Roles.ToList();
        }
        /// <summary>
        /// GetUserRoles - get user roles of the user id
        /// </summary>
        /// <param name="userId">input user id</param>
        /// <returns>list of role</returns>
        public IList<Role> GetUserRoles(int userId)
        {
            return (from ur in DatabaseContext.UserRoles
                    where ur.UserId == userId
                    select ur.Role).ToList();
        }
        /// <summary>
        /// ClearUserRoles - remove roles of the user id
        /// </summary>
        /// <param name="userId">input user id</param>
        public void ClearUserRoles(int userId)
        {
            DatabaseContext.UserRoles.RemoveRange(DatabaseContext.UserRoles.Where(ur => ur.UserId == userId));
        }
        /// <summary>
        /// UserIsInRole - check if user have a role
        /// </summary>
        /// <param name="roleId">input role id</param>
        /// <param name="userId">input user id</param>
        /// <returns>true or false</returns>
        public bool UserIsInRole(int roleId, int userId)
        {
            return (from ur in DatabaseContext.UserRoles
                    where ur.UserId == userId && ur.RoleId == roleId
                    select ur).Any();
        }
    }
}
