namespace EngineTrendMonitoring.Shared.Models.Aircraft.Requests
{
    public class CreateAircraftRequestModel
    {
        #region Properties
        public string Description { get; set; } = string.Empty;
        public string? RegNoId { get; set; }
        #endregion

        #region Constructors
        public CreateAircraftRequestModel()
        {
        }

        public CreateAircraftRequestModel(string description, string? regNoId)
        {
            Description = description;
            RegNoId = regNoId;
        }
        #endregion
    }
}
