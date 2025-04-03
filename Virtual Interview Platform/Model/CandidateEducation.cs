using System.Diagnostics;

namespace Virtual_Interview_Platform.Model
{
    public class CandidateEducation
    {
        public int EducationID {  get; set; }
        public int CandidateID  {  get; set; }
        public string Degree { get; set; }
        public string Institution {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Grade {  get; set; }
        public string CreatedAt { get; set; }
    }
}
