using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CollegePortal.Entities.Models
{
    public class TutorBookings
    {
        public int bookingId { get; set; }

        public int studentId { get; set; }

        public int tutorId { get; set; }

        public DateTime dateTime { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }
    }
}
