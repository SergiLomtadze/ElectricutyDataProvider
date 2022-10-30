using ElectricityDataProvider.BusinessLogic.Dto;

namespace ElectricityDataProvider.BusinessLogic.Features.AggregatedData.Queries.GetAllQuery
{
    public class GetAllQueryResponse
    {
        public IEnumerable<AggregatedElDataDto> Results { get; set; }
    }
}
