using System;
using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{    
    public class Paddle
    {
        /// <summary>
        /// Paddle identifier.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The paddle organiser.
        /// </summary>        
        public ApplicationUser Paddler { get; set; }

        /// <summary>
        /// Date of the paddle.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The location of the paddle.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        /// <summary>
        /// The type of paddle.
        /// </summary>
        public PaddleType PaddleType { get; set; }

        /// <summary>
        /// Gets or sets the cancelation of a paddle.
        /// </summary>
        public bool IsCancelled { get; set; }


        #region Foreign Keys

        /// <summary>
        /// Gets or sets ApplicationUser foreign key 
        /// </summary>
        [Required]
        public string PaddlerId { get; set; }


        /// <summary>
        /// Gets or sets PaddleType foreign key
        /// </summary>
        [Required]
        public byte PaddleTypeId { get; set; }

        #endregion
    }
}