using System;
using System.Collections.Generic;

namespace Domain
{
    public class Teacher
    {
        public Teacher()
        {
            Teaching = new HashSet<Teaching>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool? Sex { get; set; }
        public string Image { get; set; }
        public string Degree { get; set; }
        public DateTime Dob { get; set; }

        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}
