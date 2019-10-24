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

        public RoleDataAccessor(PrizeDrawDatabaseContext context)
        {
            _roleProvider = new RoleProvider(context);
        }

        public IList<Role> Get()
        {
            return _roleProvider.Get();
        }

        public Role GetByName(string name)
        {
            return _roleProvider.GetRoleBy(name);
        }

        public void ClearUserRoles(int userId)
        {
            _roleProvider.ClearUserRoles(userId);

            _roleProvider.Save();
        }
    }
}
