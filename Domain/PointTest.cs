namespace Domain
{
    public class PointTest
    {
        public int Id { get; set; }
        public double? Tk { get; set; }
        public double? Gk { get; set; }
        public double? Ck { get; set; }
        public double? Th { get; set; }
        public int? IdStudent { get; set; }
        public int? IdSubject { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
