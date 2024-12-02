using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegePortal.Entities.Models
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain alphabets and spaces.")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters.")]
        public string password { get; set; } = string.Empty;

        // Method to validate user credentials
        public string ValidateCredentials(string inputName, string inputPassword)
        {
            if (string.IsNullOrWhiteSpace(inputName) || string.IsNullOrWhiteSpace(inputPassword))
            {
                return "Username or password cannot be empty.";
            }

            // Simulated validation (replace with actual logic if needed)
            if (name != inputName || password != inputPassword)
            {
                return "Username or password is wrong.";
            }

            return string.Empty; // No error
        }

        // Navigation properties with default initialization
        public ICollection<GymRoomBookings> GymRoomBookings { get; set; } = new List<GymRoomBookings>();
        public ICollection<StudyRoomBookings> StudyRoomBookings { get; set; } = new List<StudyRoomBookings>();
        public ICollection<LostAndFound> LostAndFoundPosts { get; set; } = new List<LostAndFound>();
        public ICollection<TutorBookings> TutorBookings { get; set; } = new List<TutorBookings>();
    }
}
