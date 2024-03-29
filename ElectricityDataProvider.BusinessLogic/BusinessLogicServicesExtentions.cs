﻿using ElectricityDataProvider.BusinessLogic.CommandExecutor;
using ElectricityDataProvider.BusinessLogic.Features.AggregatedData;
using ElectricityDataProvider.BusinessLogic.Features.AggregatedData.Queries.GetAllQuery;
using Microsoft.Extensions.DependencyInjection;

namespace ElectricityDataProvider.BusinessLogic
{
    public static class BusinessLogicServicesExtentions
    {
        public static void AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ElDataProfile).Assembly));
            services.AddScoped<CommandInvoker>();
            services.AddScoped<ICommandHandler<GetAllQueryRequest, GetAllQueryResponse>, GetAllQueryHandler>();
        }
    }
}
