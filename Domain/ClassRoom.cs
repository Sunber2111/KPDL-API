using System.Collections.Generic;

namespace Domain
{
    public class ClassRoom
    {
        public ClassRoom()
        {
            PointTest = new HashSet<PointTest>();
            Teaching = new HashSet<Teaching>();
        }

        public int Id { get; set; }

        public string Identity { get; set; }

        public int SubjectId { get; set; }

        public int SemesterId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Semester Semester { get; set; }

        public virtual ICollection<PointTest> PointTest { get; set; }
        public virtual ICollection<Teaching> Teaching { get; set; }
    }
}