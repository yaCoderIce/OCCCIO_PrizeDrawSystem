using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model.Identity;
using Microsoft.EntityFrameworkCore;

namespace PrizeDraw.DataLayer.Providers
{
    public class UserProvider : Provider
    {
        public UserProvider(string connectionString) : base(connectionString)
        {
        }

        public UserProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IList<User> GetUsers()
        {
            return DatabaseContext.Users.Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Include(v => v.Vendor)
                .ToList();
        }

        public User GetUserBy(string userName)
        {
            return (from u in DatabaseContext.Users
                    .Include(ur => ur.UserRoles)
                    .ThenInclude(r => r.Role)
                    .Include(v => v.Vendor)
                    where u.UserName.Equals(userName)
                    select u).FirstOrDefault();
        }

        public User GetUserBy(int id)
        {
            return (from u in DatabaseContext.Users
                    .Include(ur => ur.UserRoles)
                    .ThenInclude(r => r.Role)
                    .Include(v => v.Vendor)
                    where u.Id == id
                    select u).FirstOrDefault();
        }

        public IList<User> GetUsersInRole(int roleId)
        {
            IList<User> users = (from u in GetUsers()
                                 where u.UserRoles.Any(ur => ur.Role.Id == roleId)
                                 select u).ToList();

            return users;
        }

        public void InsertUser(User user)
        {
            DatabaseContext.Add(user);
        }

        public void InsertUserRole(UserRole userRole)
        {
            DatabaseContext.UserRoles.Add(userRole);
        }
    }
}
