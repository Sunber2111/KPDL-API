using System;
using System.Collections.Generic;

namespace Domain
{
    public class Student
    {
        public Student()
        {
            PointTest = new HashSet<PointTest>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Dob { get; set; }
        public bool? Sex { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }

        public virtual ICollection<PointTest> PointTest { get; set; }

         public virtual ICollection<Order> Orders { get; set; }
    }
}
