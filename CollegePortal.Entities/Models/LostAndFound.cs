using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegePortal.Entities.Models
{
    public class LostAndFound
    {

        [Key]
        [Required]
        [Range(1, 10000, ErrorMessage = "Post ID must be between 1 and 10000.")]
        public int postId { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Student ID must be between 1 and 10000.")]
        [ForeignKey(nameof(Student))]
        public int studentId { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Item description cannot exceed 500 characters.")]
        public string itemDescription { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime foundDate { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string location { get; set; }

        // Navigation property
        public Student? Student { get; set; }
    }
}
