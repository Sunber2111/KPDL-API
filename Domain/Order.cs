using System;
namespace Domain
{
    public class Order
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

    }
}