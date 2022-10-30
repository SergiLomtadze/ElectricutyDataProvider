using ElectricityDataProvider.BusinessLogic.Dto;
using ElectricityDataProvider.BusinessLogic.Interfaces;
using ElectricityDataProvider.DataAccess.Entities;
using ExcelDataReader;
using OfficeOpenXml;

namespace ElectricityDataProvider.BusinessLogic.Features.ExcelData
{
    public class DataProcessor : IDataProcessor
    {
        #region Fields

        private readonly IApplicationDbContext _context;
        private List<ElectricityDataDto> _electricityDataDtoList;

        #endregion

        #region Constructors

        public DataProcessor(IApplicationDbContext context)
        {
            _context = context;
            _electricityDataDtoList = new List<ElectricityDataDto>();
        }

        #endregion

        #region Functions

        public void ImportDataFromExcel()
        {
            string path = @"D:\temp\data.xlsx";
            using (var excelPack = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        try
                        {
                            reader.Read();
                            while (reader.Read())
                            {
                                if (reader.GetValue(0) != null)
                                {
                                    _electricityDataDtoList.Add(new ElectricityDataDto
                                    {
                                        Region = reader.GetValue(0).ToString(),
                                        Type = reader.GetValue(1).ToString(),
                                        Number = Convert.ToInt32(reader.GetValue(3)),
                                        PPlus = reader.GetValue(4) is null ? null : Convert.ToDouble(reader.GetValue(4)),
                                        Time = Convert.ToDateTime(reader.GetValue(5)),
                                        PMinus = reader.GetValue(6) is null ? null : Convert.ToDouble(reader.GetValue(6)),
                                    });
                                }
                            }
                        }
                        catch
                        {
                            throw new Exception("Excel Reading Problem");
                        }
                    }
                }
            }
        }

        public async Task<int> WriteDataInDBAsync()
        {
            var result = _electricityDataDtoList
                .Where(x => x.Type == "Butas")
                .GroupBy(x => x.Region)
                .Select(g => new AggregatedElData
                {
                    Region = g.Key,
                    PPlus = g.Sum(x => x.PPlus),
                    PMinus = g.Sum(x => x.PMinus)
                });

            foreach (var data in result)
            {
                _context.AggregatedElDatas.Add(data);
            }
            await _context.SaveChangesAsync();

            return result.Count();
        }

        #endregion
    }
}
