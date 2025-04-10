namespace Virtual_Interview_Platform.DTO.RecruiterDto
{
    public class GetRecruitersDto
    {
        public int RecruiterID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
