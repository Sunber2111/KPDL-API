using System;
using System.Collections.Generic;

namespace Domain
{
    public class Subject
    {
        public Subject()
        {
            PointTest = new HashSet<PointTest>();
            Teaching = new HashSet<Teaching>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PointTest> PointTest { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
