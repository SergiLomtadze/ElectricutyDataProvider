using AutoMapper;
using AutoMapper.QueryableExtensions;
using ElectricityDataProvider.BusinessLogic.CommandExecutor;
using ElectricityDataProvider.BusinessLogic.Dto;
using ElectricityDataProvider.BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ElectricityDataProvider.BusinessLogic.Features.AggregatedData.Queries.GetAllQuery
{
    public class GetAllQueryHandler : ICommandHandler<GetAllQueryRequest, GetAllQueryResponse>
    {
        #region Fields

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public GetAllQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion


        #region Functions
        
        public async Task<GetAllQueryResponse> Handle(GetAllQueryRequest command)
        {
            var aggregatedElData = _context.AggregatedElDatas.AsQueryable();
            return new GetAllQueryResponse
            {
                Results = await aggregatedElData.ProjectTo<AggregatedElDataDto>(_mapper.ConfigurationProvider)
                    .ToListAsync()
            };
        }

        #endregion

    }
}
