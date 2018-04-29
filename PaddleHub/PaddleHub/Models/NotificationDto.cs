using System;

namespace PaddleHub.Models
{
    public class NotificationDto
    {
        #region Properties        
        /// <summary>
        /// Gets or sets the notificaiton datetime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the notification type
        /// </summary>
        public NotificationType NotificationType { get; private set; }

        /// <summary>
        /// Gets or sets when the original date time
        /// </summary>
        public DateTime? OriginalDateTime { get; set; }

        /// <summary>
        /// Gets or sets the original location.
        /// </summary>
        public string OriginalLocation { get; set; }

        /// <summary>
        /// Gets or sets the linked paddle for the notificaiton.
        /// </summary>        
        public PaddleDto Paddle { get; set; }
        #endregion
    }
}