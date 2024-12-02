using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegePortal.Entities.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required]
        public string name { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        // Navigation properties with default initialization
        public ICollection<GymRoomBookings> GymRoomBookings { get; set; } = new List<GymRoomBookings>();
        public ICollection<StudyRoomBookings> StudyRoomBookings { get; set; } = new List<StudyRoomBookings>();
        public ICollection<LostAndFound> LostAndFoundPosts { get; set; } = new List<LostAndFound>();
        public ICollection<TutorBookings> TutorBookings { get; set; } = new List<TutorBookings>();
    }
}
