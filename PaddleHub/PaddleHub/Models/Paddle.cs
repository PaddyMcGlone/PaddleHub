using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PaddleHub.Models
{    
    public class Paddle
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Paddle()
        {
            Attendances = new Collection<Attendance>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Paddle identifier.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The paddle organiser.
        /// </summary>        
        public ApplicationUser Paddler { get; set; }

        /// <summary>
        /// Date of the paddle.
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The location of the paddle.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        /// <summary>
        /// The type of paddle.
        /// </summary>
        public PaddleType PaddleType { get; set; }

        /// <summary>
        /// Gets or sets the cancelation of a paddle.
        /// </summary>
        public bool IsCancelled { get; private set; }

        /// <summary>
        /// A navigation property for attendances.
        /// </summary>
        public ICollection<Attendance> Attendances { get; private set; }

        #endregion

        #region Foreign Keys

        /// <summary>
        /// Gets or sets ApplicationUser foreign key 
        /// </summary>
        [Required]
        public string PaddlerId { get; set; }


        /// <summary>
        /// Gets or sets PaddleType foreign key
        /// </summary>
        [Required]
        public byte PaddleTypeId { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Mark a paddle as cancelled
        /// </summary>
        public void CancelEvent()
        {
            IsCancelled = true;

            var notification = new Notification(this, NotificationType.Cancelled);

            foreach (var attendance in Attendances.Select(a => a.Attendee))
            {
                attendance.Notify(notification);
            }                
        }
        #endregion
    }
}