
namespace PaddleHub.Models
{
    public class Attendance
    {

        #region Properties

        /// <summary>
        /// Gets or sets Paddle Attendees
        /// </summary>
        public ApplicationUser Attendee { get; set; }

        /// <summary>
        /// Gets or sets the Paddle event
        /// </summary>
        public Paddle Paddle { get; set; }

        #endregion

        #region Foreign Keys

        /// <summary>
        /// Gets or sets the Application user FK.
        /// </summary>
        public string AttendeeId { get; set; }

        /// <summary>
        /// Gets or sets the Paddle ID.
        /// </summary>
        public int PaddleID { get; set; }

        #endregion
    }
}