namespace ElectricityDataProvider.DataAccess.Entities
{
    public class AggregatedElData
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public double? PPlus { get; set; }
        public double? PMinus { get; set; }
    }
}
