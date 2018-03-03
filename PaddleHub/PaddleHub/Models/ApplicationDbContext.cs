using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PaddleHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Properties

        /// <summary>
        /// Gets or sets the paddles
        /// </summary>
        public DbSet<Paddle> Paddles { get; set; }

        /// <summary>
        /// Gets or sets the paddle types
        /// </summary>
        public DbSet<PaddleType> PaddleTypes { get; set; }


        /// <summary>
        /// Gets or sets the users address
        /// </summary>
        public DbSet<UserAddress> Addresses { get; set; }

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