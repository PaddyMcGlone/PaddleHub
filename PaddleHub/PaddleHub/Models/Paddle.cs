using System;

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
        public string Location { get; set; }

        /// <summary>
        /// The type of paddle.
        /// </summary>
        public PaddleType PaddleType { get; set; }

    }
}