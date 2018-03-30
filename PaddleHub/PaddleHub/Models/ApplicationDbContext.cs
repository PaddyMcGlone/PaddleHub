using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PaddleHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        #region Properties

        /// <summary>
        /// Gets or sets the paddles.
        /// </summary>
        public DbSet<Paddle> Paddles { get; set; }

        /// <summary>
        /// Gets or sets the paddle types.
        /// </summary>
        public DbSet<PaddleType> PaddleTypes { get; set; }


        /// <summary>
        /// Gets or sets the users address.
        /// </summary>
        public DbSet<UserAddress> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the users attendance.
        /// </summary>
        public DbSet<Attendance> Attendances { get; set; }

        /// <summary>
        /// Gets or sets the followers.
        /// </summary>
        public DbSet<Following> Followers { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create methods
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// On Model creating method
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Paddle)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}