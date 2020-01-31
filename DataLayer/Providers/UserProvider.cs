using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model.Identity;
using Microsoft.EntityFrameworkCore;
/// <summary>
/// Take Information from Database
///  
/// </summary>
namespace PrizeDraw.DataLayer.Providers
{
    public class UserProvider : Provider
    {
        /// <summary>
        /// Default Constructor, for creating user
        /// </summary>
        /// <param name="connectionString">connection string to database</param>
        public UserProvider(string connectionString) : base(connectionString)
        {
        }
        /// <summary>
        /// Get winner information from database
        /// </summary>
        /// <param name="databaseContext"></param>
        public UserProvider(PrizeDrawDatabaseContext databaseContext) : base(databaseContext)
        {
        }
        /// <summary>
        /// Get all user information from database
        /// </summary>
        /// <returns>IList of users</returns>
        public IList<User> GetUsers()
        {
            return DatabaseContext.Users.Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Include(v => v.Vendor)
                .ToList();
        }
        /// <summary>
        /// Get a specific user name of user from database
        /// </summary>
        /// <param name="userName">input user name</param>
        /// <returns>User</returns>
        public User GetUserBy(string userName)
        {
            return (from u in DatabaseContext.Users
                    .Include(ur => ur.UserRoles)
                    .ThenInclude(r => r.Role)
                    .Include(v => v.Vendor)
                    where u.UserName.Equals(userName)
                    select u).FirstOrDefault();
        }
        /// <summary>
        /// Get a specific user id of user form database
        /// </summary>
        /// <param name="id">input user id</param>
        /// <returns>User</returns>
        public User GetUserBy(int id)
        {
            return (from u in DatabaseContext.Users
                    .Include(ur => ur.UserRoles)
                    .ThenInclude(r => r.Role)
                    .Include(v => v.Vendor)
                    where u.Id == id
                    select u).FirstOrDefault();
        }
        /// <summary>
        /// Get all users of a specific role from database
        /// </summary>
        /// <param name="roleId">input role id</param>
        /// <returns>IList of users</returns>
        public IList<User> GetUsersInRole(int roleId)
        {
            IList<User> users = (from u in GetUsers()
                                 where u.UserRoles.Any(ur => ur.Role.Id == roleId)
                                 select u).ToList();

            return users;
        }
        /// <summary>
        /// Add user to database
        /// </summary>
        /// <param name="user">new User</param>
        public void InsertUser(User user)
        {
            DatabaseContext.Add(user);
        }
        /// <summary>
        /// Add user role to database
        /// </summary>
        /// <param name="userRole">new user role</param>
        public void InsertUserRole(UserRole userRole)
        {
            DatabaseContext.UserRoles.Add(userRole);
        }

    }
}
