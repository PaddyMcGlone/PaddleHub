using System;

namespace PaddleHub.Models
{
    public class PaddleDto
    {
        #region Properties       
        /// <summary>
        /// Paddle identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The paddle organiser.
        /// </summary>        
        public UserDto Paddler { get; set; }

        /// <summary>
        /// Date of the paddle.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The location of the paddle.
        /// </summary>        
        public string Location { get; set; }

        /// <summary>
        /// The type of paddle.
        /// </summary>
        public PaddleTypeDto PaddleType { get; set; }

        /// <summary>
        /// Gets or sets the cancelation of a paddle.
        /// </summary>
        public bool IsCancelled { get; set; }       
        #endregion
    }
}