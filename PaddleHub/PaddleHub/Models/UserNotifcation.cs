using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaddleHub.Models
{
    public class UserNotifcation
    {        
        #region Properties

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
        public ApplicationUser User { get; private set; }

        /// <summary>
        /// Navigation propety to notification
        /// </summary>
        public Notification Notification { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor for EF.
        /// </summary>
        protected UserNotifcation()
        {
            
        }

        /// <summary>
        /// Create new user notification constructor
        /// </summary>
        /// <param name="user"></param>
        /// <param name="notifcation"></param>
        public UserNotifcation(ApplicationUser user, Notification notifcation)
        {
            if (user == null) 
                throw new ArgumentNullException("user");
            
            if (notifcation == null) 
                throw new ArgumentNullException("notifcation");            

            User         = user;
            Notification = notifcation;
        }

        #endregion

    }
}