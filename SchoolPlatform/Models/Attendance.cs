using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int TeacherSubjectId { get; set; }
        public int StudentId { get; set; }
        public DateTime AbsenceDate { get; set; }

        public virtual TeacherSubject TeacherSubject { get; set; }
        public virtual Student Student { get; set; }
    }
}
