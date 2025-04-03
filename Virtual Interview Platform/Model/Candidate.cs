namespace Virtual_Interview_Platform.Model
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public int UserID {  get; set; }
        public string ResumeURL { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
