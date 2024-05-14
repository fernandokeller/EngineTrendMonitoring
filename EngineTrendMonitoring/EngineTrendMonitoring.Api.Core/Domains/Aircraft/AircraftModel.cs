namespace EngineTrendMonitoring.Api.Core.Domains.Aircraft
{
    public class AircraftModel
    {
        #region Properties
        public int Id { get; private set; }
        public string Registration { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region Constructors
        public AircraftModel(int id, string registration, bool active)
        {
            Id = id;
            Registration = registration;
            Active = active;
        }

        public AircraftModel(string registration)
        {
            Registration = registration;
            Active = true;
        }
        #endregion

        #region Methods

        #region Inactivate
        public void Inactivate() => Active = false;
        #endregion

        #region Activate
        public void Activate() => Active = true;
        #endregion

        #endregion

        #region Fluent Validation
        #endregion
    }
}
