namespace DiaryAPI.Models
{
    public class Note
    {
        public int Id { get; set; }

        public  string? DayEvent { get; set; }

        public DateTime? AddedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public User? User { get; set; }
    }
}
