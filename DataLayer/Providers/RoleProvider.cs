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

        public Role GetRoleBy(string roleName)
        {
            return (from r in DatabaseContext.Roles.Include(ur => ur.UserRoles)
                    where r.Name == roleName
                    select r).First();
        }

        public IList<Role> Get()
        {
            return DatabaseContext.Roles.ToList();
        }

        public IList<Role> GetUserRoles(int userId)
        {
            return (from ur in DatabaseContext.UserRoles
                    where ur.UserId == userId
                    select ur.Role).ToList();
        }

        public void ClearUserRoles(int userId)
        {
            DatabaseContext.UserRoles.RemoveRange(DatabaseContext.UserRoles.Where(ur => ur.UserId == userId));
        }

        public bool UserIsInRole(int roleId, int userId)
        {
            return (from ur in DatabaseContext.UserRoles
                    where ur.UserId == userId && ur.RoleId == roleId
                    select ur).Any();
        }
    }
}
