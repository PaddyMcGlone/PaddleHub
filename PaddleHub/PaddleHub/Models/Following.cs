
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaddleHub.Models
{
    public class Following
    {
        #region Navigational Properties
        /// <summary>
        /// Gets or sets the follower
        /// </summary>
        public ApplicationUser Follower { get; set; }

        /// <summary>
        /// Gets or sets the followee
        /// </summary>
        public ApplicationUser Followee { get; set; }
        #endregion

        #region Properties

        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }

        #endregion

        
    }
}