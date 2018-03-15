using PaddleHub.Models;
using System.Collections.Generic;

namespace PaddleHub.ViewModels
{
    /// <summary>
    /// The PaddleViewModel
    /// </summary>
    public class PaddleViewModel
    {
        /// <summary>
        /// Gets or sets the upcoming paddles
        /// </summary>
        public IEnumerable<Paddle> UpcomingPaddles { get; set; }

        /// <summary>
        /// Gets or sets if a user is authenticated
        /// </summary>
        public bool UserAuthorised { get; set; }
    }
}