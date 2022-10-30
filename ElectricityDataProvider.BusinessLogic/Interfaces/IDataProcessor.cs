using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityDataProvider.BusinessLogic.Interfaces
{
    public interface IDataProcessor
    {
        void ImportDataFromExcel();
        Task<int> WriteDataInDBAsync();
    }
}
