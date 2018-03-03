using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaddleHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        #region Properties
        
        /// <summary>
        /// Gets or sets the user first name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the user last name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }


        /// <summary>
        /// Gets or sets the users date of birth
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }


        /// <summary>
        /// Gets or sets address line 1
        /// </summary>
        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }


        /// <summary>
        /// Gets or sets address line 2
        /// </summary>
        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }


        /// <summary>
        /// Gets or sets address line 3
        /// </summary>
        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 3")]
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets address line 3
        /// </summary>
        [Required]
        [StringLength(8)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the users cani number
        /// </summary>
        [Required]
        [StringLength(4)]
        [Display(Name = "CANI Membership number")]
        public string CANIMembershipNumber { get; set; }


        /// <summary>
        /// Gets or sets any medical data
        /// </summary>
        [Display(Name = "Medical details")]
        public string MedicalDetails { get; set; }

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
        /// Concat the users first and last name 
        /// </summary>
        /// <returns>The users first name</returns>
        public string Name()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        #endregion
    }
}