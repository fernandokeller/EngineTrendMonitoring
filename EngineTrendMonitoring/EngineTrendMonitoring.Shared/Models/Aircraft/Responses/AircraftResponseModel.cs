namespace EngineTrendMonitoring.Shared.Models.Aircraft.Responses
{
    public class AircraftResponseModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? RegNoId { get; set; }
        public bool Active { get; set; }
    }
}
