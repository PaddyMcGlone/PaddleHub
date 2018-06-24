namespace PaddleHub.Models
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

        // Check attendance should become and extension method of paddler.
        public bool AttendingPaddle { get { return CheckAttendance() }; set; }

        /// <summary>
        /// Gets or sets who the user is following.
        /// </summary>
        public bool Following { get; set; }

        #endregion

        #region Methods
        
        #endregion
    }
}