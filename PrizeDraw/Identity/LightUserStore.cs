using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PrizeDraw.DataLayer.Providers;
using Microsoft.AspNetCore.Identity;
using PrizeDraw.DataLayer;
using PrizeDraw.DataLayer.Model.Identity;
using PrizeDraw.DataLayer.DataAccess;

namespace PrizeDraw.Identity
{
    public class LightUserStore : IUserRoleStore<User>, IUserPasswordStore<User>
    {
        private UserDataAccessor UserDataAccessor { get; set; }

        private RoleDataAccessor RoleDataAccessor { get; set; }

        public LightUserStore(PrizeDrawDatabaseContext databaseContext)
        {
            UserDataAccessor = new UserDataAccessor(databaseContext);
            RoleDataAccessor = new RoleDataAccessor(databaseContext);
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            UserDataAccessor.CreateUser(user);

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(UserDataAccessor.Get(Convert.ToInt32(userId)));
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(UserDataAccessor.GetByUsername(normalizedUserName));
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName.ToLower());
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            // How about lowercase. The identity system seems to like uppercase. I don't, so lowercase it right here.
            user.UserName = normalizedName.ToLower();

            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;

            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            UserDataAccessor.UpdateUser(user.Id, user);
                        
            return Task.FromResult(IdentityResult.Success);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            UserDataAccessor.AddUserToRole(user.Id, roleName);

            return Task.FromResult(default(Task));
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            IList<string> userRoles = user.UserRoles != null ? 
                user.UserRoles.Select(ur => ur.Role.Name).ToList() : new List<string>();
                  
            return Task.FromResult(userRoles);
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            bool isInRole = false;

            if (user.UserRoles != null && user.UserRoles.Count > 0)
            {
                isInRole = user.UserRoles.Any(r => r.Role.Name == roleName);
            }

            return Task.FromResult(isInRole); 
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            Role role = RoleDataAccessor.GetByName(roleName);

            return Task.FromResult(UserDataAccessor.GetUsersInRole(role.Id));
        }

        public void Dispose()
        {
        }
    }
}
