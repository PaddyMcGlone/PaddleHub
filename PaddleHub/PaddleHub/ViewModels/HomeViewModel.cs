using System.Collections.Generic;
using PaddleHub.Models;

namespace PaddleHub.ViewModels
{
    /// <summary>
    /// The HomeViewModel
    /// </summary>
    public class HomeViewModel
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