using System.ComponentModel.DataAnnotations;

namespace PaddleHub.Models
{
    public class PaddleType
    {
        /// <summary>
        /// Paddle type identifier.
        /// </summary>
        public byte Id { get; set; }

        /// <summary>
        /// Paddle type name.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}