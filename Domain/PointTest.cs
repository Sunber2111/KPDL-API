using System;
using System.Collections.Generic;

namespace Domain
{
    public class PointTest
    {
        public Guid Id { get; set; }
        public double? Tk { get; set; }
        public double? Gk { get; set; }
        public double? Ck { get; set; }
        public double? Th { get; set; }
        public Guid? IdStudent { get; set; }
        public Guid? IdSubject { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual Subject IdSubjectNavigation { get; set; }
    }
}
