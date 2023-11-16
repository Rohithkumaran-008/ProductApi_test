using AutoMapper;
using ProductDetails.DTO;
using ProductDetails.Model;

namespace ProductDetails.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateIssueDto, Issues>().ReverseMap();
            CreateMap<GetIssueDto, Issues>().ReverseMap();

            CreateMap<CreateIssueDetailDto, IssueDetail>().ReverseMap();
            CreateMap<GetIssueDetailDto, IssueDetail>().ReverseMap();
        }
    }
}
