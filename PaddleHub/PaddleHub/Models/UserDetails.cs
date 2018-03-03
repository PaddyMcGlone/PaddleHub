using System;
using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{
    public class UserDetails
    {
        #region Properties

        /// <summary>
        /// User details identifier
        /// </summary>
        public int Id { get; set; }

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
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the users cani number
        /// </summary>
        [Required]
        [StringLength(4)]
        public string CANIMembershipNumber { get; set; }


        /// <summary>
        /// Gets or sets any medical data
        /// </summary>        
        public string MedicalDetails { get; set; }

        #endregion

        #region Methods
        
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