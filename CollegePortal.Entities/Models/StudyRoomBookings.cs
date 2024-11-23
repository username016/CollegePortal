using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegePortal.Entities.Models
{
    public class StudyRoomBookings
    {
        public int bookingId { get; set; }

        public int studentId { get; set; }

        public int studyRoomId { get; set; }

        public DateTime dateTime { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }
    }
}
