using System;
using System.Collections.Generic;

namespace Domain
{
    public class Teaching
    {
        public Guid Id { get; set; }
        public Guid? IdSubject { get; set; }
        public Guid? IdTeacher { get; set; }
        public string Location { get; set; }
        public string TeachDay { get; set; }

        public virtual Subject IdSubjectNavigation { get; set; }
        public virtual Teacher IdTeacherNavigation { get; set; }
    }
}
