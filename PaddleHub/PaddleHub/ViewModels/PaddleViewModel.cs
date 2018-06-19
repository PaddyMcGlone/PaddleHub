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
        /// Gets or sets the upcoming paddles.
        /// </summary>
        public IEnumerable<Paddle> UpcomingPaddles { get; set; }

        /// <summary>
        /// Gets or sets if a user is authenticated.
        /// </summary>
        public bool UserAuthorised { get; set; }

        /// <summary>
        /// Gets or sets the page heading.
        /// </summary>
        public string Heading { get; set; }

        /// <summary>
        /// Gets or sets the searching term.
        /// </summary>
        public string SearchTerm { get; set; }
    }
}