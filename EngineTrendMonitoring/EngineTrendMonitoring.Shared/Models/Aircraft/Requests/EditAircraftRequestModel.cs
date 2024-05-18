namespace EngineTrendMonitoring.Shared.Models.Aircraft.Requests
{
    public class EditAircraftRequestModel
    {
        #region Properties
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? RegNoId { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Constructors
        public EditAircraftRequestModel()
        {
        }

        public EditAircraftRequestModel(int id, string description, string? regNoId, bool active)
        {
            Id = id;
            Description = description;
            RegNoId = regNoId;
            Active = active;
        }
        #endregion
    }
}
