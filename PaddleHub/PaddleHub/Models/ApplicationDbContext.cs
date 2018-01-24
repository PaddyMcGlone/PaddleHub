using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PaddleHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Properties

        /// <summary>
        /// The Paddles DBSet
        /// </summary>
        public DbSet<Paddle> Paddles { get; set; }

        /// <summary>
        /// The PaddleTypes Dbset
        /// </summary>
        public DbSet<PaddleType> PaddleTypes { get; set; }

        #endregion

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}