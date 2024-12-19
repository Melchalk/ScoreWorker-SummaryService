using AutoMapper;
using SummaryService.Models.Db;
using SummaryService.Models.Dto.Requests;
using SummaryService.Models.Dto.Responses;

namespace SummaryService.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DbSummary, CreateSummaryRequest>().ReverseMap();
        CreateMap<DbSummary, GetSummaryResponse>().ReverseMap();
    }
}
