namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Requests
{
    public class CreateEngineTrendRequestModel
    {
        public int AircraftId { get; set; }
        public DateTime CollectionDate { get; set; }
        public int FlightHours { get; set; }
    }
}
