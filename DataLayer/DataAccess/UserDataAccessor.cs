using System;
using System.Collections.Generic;
using System.Text;
using PrizeDraw.DataLayer.Providers;
using PrizeDraw.DataLayer.Model;
using PrizeDraw.DataLayer.Model.Identity;
using System.Linq;

namespace PrizeDraw.DataLayer.DataAccess
{
    public class UserDataAccessor
    {
        private UserProvider _userProvider;
        private RoleProvider _roleProvider;
        /// <summary>
        /// Default Constructor
        /// Create new record in UserRoles table
        /// </summary>
        /// <param name="context"></param>
        public UserDataAccessor(PrizeDrawDatabaseContext context)
        {
            _userProvider = new UserProvider(context);
            _roleProvider = new RoleProvider(context);
        }
        /// <summary>
        /// Get - get all users
        /// </summary>
        /// <returns>List of users</returns>
        public IList<User> Get()
        {
            return _userProvider.GetUsers();
        }
        /// <summary>
        /// Get - Get user by id
        /// </summary>
        /// <param name="userId">input user id</param>
        /// <returns></returns>
        public User Get(int userId)
        {
            return _userProvider.GetUserBy(userId);
        }
        /// <summary>
        /// GetByUsername - Get User by username
        /// </summary>
        /// <param name="userName">input user name</param>
        /// <returns>user</returns>
        public User GetByUsername(string userName)
        {
            return _userProvider.GetUserBy(userName);
        }
        /// <summary>
        /// GetUsersInRole - Gets User by role
        /// </summary>
        /// <param name="roleId">input role id</param>
        /// <returns>list of users</returns>
        public IList<User> GetUsersInRole(int roleId)
        {
            return _userProvider.GetUsersInRole(roleId);
        }
        /// <summary>
        /// CreareUser - Create new user
        /// </summary>
        /// <param name="user">new User Information</param>
        public void CreateUser(User user)
        {
            _userProvider.InsertUser(user);

            _userProvider.Save();
        }
        /// <summary>
        /// CreateUser - Create new user in database with a role
        /// </summary>
        /// <param name="user">new user</param>
        /// <param name="roleIds">role id</param>
        public void CreateUser(User user, IList<int> roleIds)
        {
            CreateUser(user);

            foreach(int roleId in roleIds)
            {
                _userProvider.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId
                });
            }

            _userProvider.Save();
        }
        /// <summary>
        /// AddUserToRole - add user to the role
        /// </summary>
        /// <param name="userId">Input User ID</param>
        /// <param name="roleName">Input Role Name</param>
        public void AddUserToRole(int userId, string roleName)
        {
            AddUserToRole(userId, _roleProvider.GetRoleBy(roleName).Id);
        }
        /// <summary>
        /// AddUserToRole - Add Role for the user on UserRoles table
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="roleId">Role ID</param>
        public void AddUserToRole(int userId, int roleId)
        {
            _userProvider.Add(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });

            _userProvider.Save();
        }
        /// <summary>
        /// UpdateUser - Update User Information
        /// </summary>
        /// <param name="id">user Id</param>
        /// <param name="user">new user information</param>
        public void UpdateUser(int id, User user)
        {
            User oldUser = _userProvider.GetUserBy(id);

            oldUser.PasswordHash = user.PasswordHash;
            oldUser.VendorId = user.VendorId;

            _userProvider.Save();
        }
    }
}
