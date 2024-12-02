using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollegePortal.Entities.Models
{
    public class TutorBookings
    {
        [Key]
        [Required]
        [Range(1, 10000, ErrorMessage = "Booking ID must be between 1 and 10000.")]
        public int bookingId { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Student ID must be between 1 and 10000.")]
        [ForeignKey(nameof(Student))]
        public int studentId { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Tutor ID must be between 1 and 1000.")]
        public int tutorId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime startTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime endTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime dateTime { get; set; }

        // Navigation property
        public Student? Student { get; set; }

        [NotMapped]
        public TimeSpan Duration => endTime - startTime;
    }
}
