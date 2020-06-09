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
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PointTest> PointTest { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
         public virtual ICollection<Order> Orders { get; set; }
    }
}
