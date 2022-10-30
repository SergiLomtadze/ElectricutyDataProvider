using ElectricityDataProvider.BusinessLogic.CommandExecutor;
using ElectricityDataProvider.BusinessLogic.Features.AggregatedData.Queries.GetAllQuery;
using ElectricityDataProvider.BusinessLogic.Features.ExcelData;
using ElectricityDataProvider.BusinessLogic.Interfaces;
using ElectricityDataProvider.DataAccess.Entities;
using ElectricityDataProvider.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectricityDataProvider.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        #region Fields

        private readonly CommandInvoker _commandInvoker;
        private readonly DataProcessor _dataProcessor;
        private readonly ILogger<DataController> _logger;
        #endregion

        #region Constructors

        public DataController(ApplicationDbContext context, 
            CommandInvoker commandInvoker,
            ILogger<DataController> logger)
        {
            _dataProcessor = new DataProcessor(context);
            _commandInvoker = commandInvoker;
            _logger = logger;
        }

        #endregion

        #region Actions

        [HttpGet("GetAggregatedData")]
        public async Task<ActionResult<GetAllQueryResponse>> GetAggregatedData()
        {
            _logger.LogInformation($"Getting information from db at:{ DateTime.Now.ToString()}");
            
            var result = await _commandInvoker.Invoke(new GetAllQueryRequest { });            
            return Ok(result);
        }

        [HttpPost("FillDbFromExcel")]
        public async Task<ActionResult<string>> FillDbFromExcel()
        {
            _logger.LogInformation($"Importing information from excel into db at:{DateTime.Now.ToString()}");
            
            _dataProcessor.ImportDataFromExcel();
            var insertedRowsNumber = await _dataProcessor.WriteDataInDBAsync();

            return Ok($"{insertedRowsNumber} rows were added to DB");
        }

        #endregion
    }
}
