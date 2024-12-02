﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegePortal.Entities.Models
{
    public class StudyRoomBookings
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
        [Range(1, 100, ErrorMessage = "Study Room ID must be between 1 and 100.")]
        public int studyRoomId { get; set; }

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
