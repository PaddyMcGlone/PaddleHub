﻿using Microsoft.AspNet.Identity;
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
        /// Gets or sets the user first name
        /// </summary>
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the user last name
        /// </summary>
        public string LastName { get; set; }

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