﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{
    public class Notification
    {
        /// <summary>
        /// Gets or sets the notification id
        /// </summary>
        public int Id { get; set; }        

        /// <summary>
        /// Gets or sets the notificaiton datetime
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the notification type
        /// </summary>
        public NotificationType NotificationType { get; set; }

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
        [Required]
        public Paddle Paddle { get; set; }
    }
}