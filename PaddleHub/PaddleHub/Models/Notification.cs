using System;
using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{
    public class Notification
    {
        #region Properties
        /// <summary>
        /// Gets or sets the notification id
        /// </summary>
        public int Id { get; set; }        

        /// <summary>
        /// Gets or sets the notificaiton datetime
        /// </summary>
        public DateTime DateTime { get; private set; }

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
        [Required]
        public Paddle Paddle { get; private set; }
        

        #endregion

        #region Constructor

        /// <summary>
        /// The default constructor for entity framework
        /// </summary>
        protected Notification()
        {
            
        }

        /// <summary>
        /// The notification custom constructor
        /// </summary>
        /// <param name="paddle"></param>
        /// <param name="notificationType"></param>
        protected Notification(Paddle paddle, NotificationType notificationType)
        {
            if (paddle == null)
                throw new ArgumentNullException("paddle");

            DateTime         = DateTime.Now;
            Paddle           = paddle;
            NotificationType = notificationType;
        }

        #endregion

        #region Factory methods

        /// <summary>
        /// The Added new paddle notification factory method.
        /// </summary>
        /// <param name="paddle"></param>
        /// <returns>A new paddle notification</returns>
        public static Notification CreateNotificatio(Paddle paddle)
        {
            return new Notification(paddle, NotificationType.Added);
        }

        /// <summary>
        /// The cancel notification factory method
        /// </summary>
        /// <param name="paddle"></param>
        /// <returns>A cancel notification</returns>
        public static Notification CancelNotification(Paddle paddle)
        {
            return new Notification(paddle, NotificationType.Cancelled);
        }

        /// <summary>
        /// The Update notification factory method
        /// </summary>        
        /// <param name="Newpaddle"></param>
        /// <param name="originalDateTime"></param>
        /// <param name="originalLocation"></param>
        /// <returns>An update notificaiton</returns>
        public static  Notification UpdateNotification(Paddle Newpaddle, DateTime originalDateTime, string originalLocation)
        {
            return new Notification(Newpaddle, NotificationType.Modified)
            {
                OriginalDateTime = originalDateTime,
                OriginalLocation = originalLocation
            };
        } 
        #endregion
    }
}