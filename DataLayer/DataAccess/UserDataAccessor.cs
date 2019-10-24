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

        public UserDataAccessor(PrizeDrawDatabaseContext context)
        {
            _userProvider = new UserProvider(context);
            _roleProvider = new RoleProvider(context);
        }

        public IList<User> Get()
        {
            return _userProvider.GetUsers();
        }

        public User Get(int userId)
        {
            return _userProvider.GetUserBy(userId);
        }

        public User GetByUsername(string userName)
        {
            return _userProvider.GetUserBy(userName);
        }

        public IList<User> GetUsersInRole(int roleId)
        {
            return _userProvider.GetUsersInRole(roleId);
        }

        public void CreateUser(User user)
        {
            _userProvider.InsertUser(user);

            _userProvider.Save();
        }

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

        public void AddUserToRole(int userId, string roleName)
        {
            AddUserToRole(userId, _roleProvider.GetRoleBy(roleName).Id);
        }

        public void AddUserToRole(int userId, int roleId)
        {
            _userProvider.Add(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });

            _userProvider.Save();
        }

        public void UpdateUser(int id, User user)
        {
            User oldUser = _userProvider.GetUserBy(id);

            oldUser.PasswordHash = user.PasswordHash;
            oldUser.VendorId = user.VendorId;

            _userProvider.Save();
        }
    }
}
