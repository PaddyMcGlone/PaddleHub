using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaddleHub.Models
{
    public class UserNotifcation
    {
        /// <summary>
        /// Gets or sets the User id
        /// </summary>
        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the notification id
        /// </summary>
        [Key, Column(Order = 2)]
        public int NotificationId { get; set; }

        /// <summary>
        /// Gets or sets if a notification has been read by a user
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Naviation property to user
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Navigation propety to notification
        /// </summary>
        public Notification Notification { get; set; }
    }
}