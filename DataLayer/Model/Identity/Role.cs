using System.Collections.Generic;

namespace PrizeDraw.DataLayer.Model.Identity
{
    /// <summary>
    /// Role Class
    /// used to generate role
    /// @see Roles table
    /// </summary>
    public class Role
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<UserRole> UserRoles { get; set; }
    }
}
