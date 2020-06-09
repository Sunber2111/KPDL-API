using System;
using System.Collections.Generic;

namespace Domain
{
    public class Teaching
    {
        public int Id { get; set; }
        public int? IdSubject { get; set; }
        public int? IdTeacher { get; set; }
        public string Location { get; set; }
        public string TeachDay { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
