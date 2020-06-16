namespace Domain
{
    public class Teaching
    {
        public int Id { get; set; }
        public int? ClassRoomId { get; set; }
        public int? IdTeacher { get; set; }
        public string Location { get; set; }
        public string TeachDay { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
