using EngineTrendMonitoring.Shared.Models.Result;

namespace EngineTrendMonitoring.Shared.Exceptions
{
    public class CustomException : Exception
    {
        #region Properties
        public ResultModel ResultModel { get; private set; }
        #endregion

        #region Constructors
        public CustomException(ResultModel resultModel)
        {
            ResultModel = resultModel;
        }

        public CustomException(string errorMessage)
        {
            ResultModel = ResultModel.WithError(errorMessage);
        }

        public CustomException(IEnumerable<string> errors)
        {
            ResultModel = ResultModel.WithErrors(errors);
        }
        #endregion
    }
}
