﻿using System.Collections.Generic;

namespace Domain
{
    public class Subject
    {
        public Subject()
        {
            Orders = new HashSet<Order>();
            ClassRooms = new HashSet<ClassRoom>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}
