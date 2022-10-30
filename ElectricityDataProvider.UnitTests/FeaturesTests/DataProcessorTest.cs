using ElectricityDataProvider.BusinessLogic.Features.ExcelData;
using ElectricityDataProvider.BusinessLogic.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ElectricityDataProvider.UnitTests.FeaturesTests
{
    public class DataProcessorTest
    {
        [Fact]
        public void ImportDataFromExcel_WhenExcelDataIsNotCorrect_ThrowsException()
        {
            //Arrange            
            var dataProcessorMock = new Mock<IDataProcessor>();
            dataProcessorMock.Setup(x => x.ImportDataFromExcel())
                .Throws<Exception>();

            //Act Assert
            Assert.Throws<Exception>(() => dataProcessorMock.Object.ImportDataFromExcel());
        }

        [Fact]
        public async Task WriteDataInDBAsync_WhenDataIsCorrect_ReturnsExpectedValue()
        {
            //Arrange
            var expectedResult = 1;
            var dataProcessorMock = new Mock<IDataProcessor>();
            dataProcessorMock.Setup(x => x.WriteDataInDBAsync())
                .ReturnsAsync(1);

            //Act
            var result = await dataProcessorMock.Object.WriteDataInDBAsync();

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
