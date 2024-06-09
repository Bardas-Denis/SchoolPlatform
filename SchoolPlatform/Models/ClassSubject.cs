using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlatform.Models
{
    public class ClassSubject
    {
        public int ClassSubjectId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; } 
    }
}
