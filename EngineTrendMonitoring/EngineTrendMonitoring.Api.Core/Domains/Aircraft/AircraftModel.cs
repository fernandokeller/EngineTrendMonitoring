using EngineTrendMonitoring.Shared.Exceptions;
using EngineTrendMonitoring.Shared.Models.Aircraft.Constraints;
using EngineTrendMonitoring.Shared.Models.Aircraft.Messages;
using FluentValidation;

namespace EngineTrendMonitoring.Api.Core.Domains.Aircraft
{
    public class AircraftModel
    {
        #region Properties
        public int Id { get; private set; }
        public string Description { get; private set; }
        public string? RegNoId { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region Constructors

        #region Restore
        public AircraftModel(int id, string description, string? regNoId, bool active)
        {
            Id = id;
            Description = description;
            RegNoId = regNoId;
            Active = active;
        }
        #endregion

        #region Create
        public AircraftModel(string description, string? regNoId)
        {
            Description = description;
            RegNoId = regNoId;
            Active = true;

            Validate();
        }
        #endregion

        #endregion

        #region Methods

        #region Update
        public void Update(string description, string? regNoId, bool active)
        {
            Description = description;
            RegNoId = regNoId;
            Active = active;

            Validate();
        }
        #endregion

        #region Inactivate
        public void Inactivate()
        {
            Active = false;
            Validate();
        }
        #endregion

        #region Validate
        public void Validate()
        {
            var validationResult = new AircraftModelValidator().Validate(this);

            if (!validationResult.IsValid)
                throw new CustomException(validationResult.Errors.Select(x => x.ErrorMessage));
        }
        #endregion

        #endregion
    }

    #region Fluent Validation
    public class AircraftModelValidator : AbstractValidator<AircraftModel>
    {
        public AircraftModelValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.Active).Equal(true).When(IsCreateMode).WithMessage("You cannot create an inactive entry");

            RuleFor(x => x.Description).NotEmpty().WithMessage(AircraftErrorMessages.DESCRIPTION_IS_REQUIRED);

            RuleFor(x => x.Description)
                .MaximumLength(AircraftConstraints.DESCRIPTION_MAX_LENGTH)
                .WithMessage(string.Format(AircraftErrorMessages.DESCRIPTION_MAX_LENGTH_IS_X, AircraftConstraints.DESCRIPTION_MAX_LENGTH));

            RuleFor(x => x.RegNoId)
                .MaximumLength(AircraftConstraints.REGNOID_MAX_LENGTH)
                .When(x => x.RegNoId is not null)
                .WithMessage(string.Format(AircraftErrorMessages.REGNOID_MAX_LENGTH_IS_X, AircraftConstraints.REGNOID_MAX_LENGTH));
        }

        internal bool IsCreateMode(AircraftModel aircraftModel) => aircraftModel.Id == 0;
        internal bool IsEditMode(AircraftModel aircraftModel) => aircraftModel.Id > 0;
    }
    #endregion
}
