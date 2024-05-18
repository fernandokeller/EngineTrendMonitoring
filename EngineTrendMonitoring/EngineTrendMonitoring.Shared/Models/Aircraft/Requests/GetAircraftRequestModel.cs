namespace EngineTrendMonitoring.Shared.Models.Aircraft.Requests
{
    public class GetAircraftRequestModel
    {
        public int? Id { get; set; } = null;
        public string? Description { get; set; } = null;
        public string? RegNoId { get; set; } = null;
        public bool? Active { get; set; } = null;
    }
}
