using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegePortal.Entities.Models
{
    public class LostAndFound
    {

        public int postId { get; set; }
        public int studentId{ get; set; }
        public string itemDescription { get; set; }
        public DateTime foundDate { get; set; } 

        public string location { get; set; }
    }
}
