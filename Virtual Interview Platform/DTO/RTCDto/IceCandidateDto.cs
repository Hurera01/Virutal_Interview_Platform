namespace Virtual_Interview_Platform.DTO.RTCDto
{
    public class IceCandidateDto
    {
        public string Candidate { get; set; } = string.Empty;
        public string SdpMid { get; set; } = string.Empty;
        public int SdpMLineIndex { get; set; }
    }
}
