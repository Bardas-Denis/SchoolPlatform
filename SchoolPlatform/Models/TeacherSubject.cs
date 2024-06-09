using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class TeacherSubject
    {
        public int TeacherSubjectId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public virtual Teacher Teacher { get; set; } 
        public virtual Subject Subject { get; set; } 
        public virtual Grade Grade { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
