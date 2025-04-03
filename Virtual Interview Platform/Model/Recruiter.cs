namespace Virtual_Interview_Platform.Model
{
    public class Recruiter
    {
        public int RecruiterID  { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
