using System;
using System.ComponentModel.DataAnnotations;

namespace PaddleHub.ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// Gets or sets first name
        /// </summary>
        [Required]
        [StringLength(30)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name
        /// </summary>
        [Required]
        [StringLength(30)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Address line 3")]
        public string AddressLine3 { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "CANI Membership number")]
        public string CANIMembershipNumber { get; set; }

        [Display(Name = "Medical details")]
        public string MedicalDetails { get; set; }

        /// <summary>
        // Gets or sets email
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        /// <summary>
        /// Gets or sets the password confirmation
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}