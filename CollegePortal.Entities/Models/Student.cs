using System.ComponentModel.DataAnnotations;

namespace CollegePortal.Entities.Models
{
    public class Student
    { 
        [Key]
        [Required]
        [Range(1, 10000, ErrorMessage = "Student ID must be between 1 and 10000.")]
        public int studentId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name must contain only letters, spaces, hyphens, and apostrophes.")]
        public string name { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must contain at least one letter, one number, and one special character.")]
        public string password { get; set; }

        // Navigation properties for related entities
        public ICollection<LostAndFound>? LostAndFoundPosts { get; set; }
        public ICollection<GymRoomBookings>? GymRoomBookings { get; set; }
        public ICollection<StudyRoomBookings>? StudyRoomBookings { get; set; }
        public ICollection<TutorBookings>? TutorBookings { get; set; }
    }
}
