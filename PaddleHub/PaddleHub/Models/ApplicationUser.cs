using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaddleHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        #region Properties  

        /// <summary>
        /// User details navigation property 
        /// </summary>
        public UserDetails UserDetails { get; set; }
    
        /// <summary>
        /// Address navigation property
        /// </summary>
        public UserAddress Address { get; set; } 

        #endregion

        #region Foreign keys

        /// <summary>
        /// Gets or sets the user details ID foreign key
        /// </summary>
        public int UserDetailsId { get; set; } 

        /// <summary>
        /// Gets or sets the Address ID foreign key
        /// </summary>
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
        
        #endregion
    }
}