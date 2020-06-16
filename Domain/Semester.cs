using System.Collections.Generic;

namespace Domain
{
    public class Semester
    {
        public Semester()
        {
            ClassRooms = new HashSet<ClassRoom>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}