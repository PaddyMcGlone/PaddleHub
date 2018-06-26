
using PaddleHub.Models;

namespace PaddleHub.ViewModels
{
    public class PaddleDetailsViewModel
    {        
        #region Properties

        /// <summary>
        /// Gets or sets the paddle details.
        /// </summary>
        public Paddle Paddle { get; set; }

        /// <summary>
        /// Gets or sets if the user is attending the paddle.
        /// </summary>
        public bool isAttending { get; set; }
    
        /// <summary>
        /// Gets or sets who the user is following.
        /// </summary>
        public bool isFollowing { get; set; }

        #endregion

    }
}