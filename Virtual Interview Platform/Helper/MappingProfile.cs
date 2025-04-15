using AutoMapper;
using Virtual_Interview_Platform.DTO.CandidateDto;
using Virtual_Interview_Platform.DTO.CandidateEducationDto;
using Virtual_Interview_Platform.DTO.CandidateExperienceDto;
using Virtual_Interview_Platform.DTO.RecruiterDto;
using Virtual_Interview_Platform.Model;

namespace Virtual_Interview_Platform.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRecruiterDto, Recruiter>().ReverseMap();
            CreateMap<GetRecruitersDto, Recruiter>().ReverseMap();
            CreateMap<UpdateRecruiterDto, Recruiter>().ReverseMap();
            CreateMap<DeleteRecruiterDto, Recruiter>().ReverseMap();

            CreateMap<CreateCandidateDto, Candidate>().ReverseMap();
            CreateMap<GetCandidateDto, Candidate>().ReverseMap();
            CreateMap<UpdateCandidateDto, Candidate>().ReverseMap();
            CreateMap<DeleteCandidateDto, Candidate>().ReverseMap();

            CreateMap<CreateCandidateEducationDto, CandidateEducation>().ReverseMap();
            CreateMap<GetCandidateEducationDto, CandidateEducation>().ReverseMap();
            CreateMap<UpdateCandidateEducationDto, CandidateEducation>().ReverseMap();

            CreateMap<CreateCandidateExperienceDto, CandidateExperience>().ReverseMap();
            CreateMap<GetCandidateExperienceDto, CandidateExperience>().ReverseMap();
            CreateMap<UpdateCandidateExperienceDto, CandidateExperience>().ReverseMap();
        }
    }
}
