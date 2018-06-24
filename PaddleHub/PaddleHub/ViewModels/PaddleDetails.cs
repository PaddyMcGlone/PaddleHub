
using PaddleHub.Models;

namespace PaddleHub.ViewModels
{
    public class PaddleDetails
    {
        #region Properties

        /// <summary>
        /// Gets or sets the paddle details.
        /// </summary>
        public Paddle Paddle { get; set; }

        /// <summary>
        /// Gets or sets if the user has logged in.
        /// </summary>
        public bool UserAuthorised { get; set; }        

        /// <summary>
        /// Gets or sets who the user is following.
        /// </summary>
        public bool Following { get; set; }

        #endregion

    }
}