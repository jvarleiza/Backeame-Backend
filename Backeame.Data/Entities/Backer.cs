using Backeame.Data.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Backeame.Data.Entities
{
    public class Backer : IdentityUser, ISoftDelete
    {
        /// <summary>
        /// Address of the user
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Surname of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Soft Delete property
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
