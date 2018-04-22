using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaddleHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region Constructor

        /// <summary>
        /// A default constructor for application user
        /// </summary>
        public ApplicationUser()
        {
            Followers        = new Collection<Following>();
            Followees        = new Collection<Following>();
            UserNotifcations = new Collection<UserNotifcation>();
        }
        #endregion

        #region Properties

        /// <summary>
        /// User details navigation property 
        /// </summary>
        public UserDetails UserDetails { get; set; }
    
        /// <summary>
        /// Address navigation property
        /// </summary>
        public UserAddress Address { get; set; }

        /// <summary>
        /// A list of users currently following this paddler
        /// </summary>
        public ICollection<Following> Followers { get; set; }

        /// <summary>
        /// A list of users this user is currently following
        /// </summary>
        public ICollection<Following> Followees { get; set; }

        /// <summary>
        /// Gets or sets a user notification navigational property
        /// </summary>
        public ICollection<UserNotifcation> UserNotifcations { get; set; }

        #endregion

        #region Foreign keys

        /// <summary>
        /// Gets or sets the user details ID foreign key
        /// </summary>
        [Required]
        public int UserDetailsId { get; set; } 

        /// <summary>
        /// Gets or sets the Address ID foreign key
        /// </summary>
        [Required]
        public int AddressId { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Generate user identity Async
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        /// <summary>
        /// A helper method to help persist a user notification.
        /// </summary>
        /// <param name="notification"></param>
        public void Notify(Notification notification)
        {
            var userNotification = new UserNotifcation
            {
                User = this,
                Notification = notification
            };
            UserNotifcations.Add(userNotification);
        }
        
        #endregion        
    }
}