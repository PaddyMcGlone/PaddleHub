using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{
    public class UserAddress
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Address ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets address line 1
        /// </summary>
        [Required]
        [StringLength(30)]        
        public string AddressLine1 { get; set; }


        /// <summary>
        /// Gets or sets address line 2
        /// </summary>
        [Required]
        [StringLength(30)]        
        public string AddressLine2 { get; set; }


        /// <summary>
        /// Gets or sets address line 3
        /// </summary>
        [Required]
        [StringLength(30)]        
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets address line 3
        /// </summary>
        [Required]
        [StringLength(8)]        
        public string Postcode { get; set; }

        #endregion
    }
}