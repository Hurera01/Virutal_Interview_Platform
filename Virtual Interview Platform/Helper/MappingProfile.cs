using AutoMapper;
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
            //CreateMap<Recruiter, CreateRecruiterDto>();

            //CreateMap(typeof(IEnumerable<>), typeof(IEnumerable<>));
            //CreateMap(typeof(IQueryable<>), typeof(IQueryable<>));
        }
    }
}
