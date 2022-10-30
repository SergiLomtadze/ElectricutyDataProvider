using AutoMapper;
using ElectricityDataProvider.BusinessLogic.Dto;
using ElectricityDataProvider.DataAccess.Entities;

namespace ElectricityDataProvider.BusinessLogic.Features.AggregatedData
{
    public class ElDataProfile : Profile
    {
        public ElDataProfile()
        {
            CreateMap<AggregatedElData, AggregatedElDataDto>();
        }
    }
}
