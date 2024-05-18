using EngineTrendMonitoring.Shared.ExtensionMethods;

namespace EngineTrendMonitoring.Shared.Models.Result
{
    public class ResultModel<T>
    {
        #region Properties
        public bool Success { get; private set; }
        public T? ResultData { get; private set; }
        public IEnumerable<string> Errors { get; private set; } = Enumerable.Empty<string>();
        #endregion

        #region Constructors
        public ResultModel(bool success, T? resultData, IEnumerable<string> errors)
        {
            Success = success;
            ResultData = resultData;
            Errors = errors;
        }

        private ResultModel()
        {
        }

        public static implicit operator ResultModel(ResultModel<T> resultModel)
        {
            return new ResultModel(resultModel.Success, resultModel.ResultData, resultModel.Errors);
        }
        #endregion

        #region Public Methods

        #region With Success
        public static ResultModel<T> WithSuccess(T? resultData)
        {
            return new ResultModel<T>() { Success = true, ResultData = resultData };
        }
        #endregion

        #region With Error
        public static ResultModel<T> WithError(string errorMessage)
        {
            return new ResultModel<T>() { Success = false, Errors = [errorMessage] };
        }
        #endregion

        #region With Errors
        public static ResultModel<T> WithErrors(IEnumerable<string> errors)
        {
            return new ResultModel<T>() { Success = false, Errors = errors };
        }
        #endregion

        #endregion
    }

    public class ResultModel
    {
        #region Properties
        public bool Success { get; private set; }
        public dynamic? ResultData { get; private set; }
        public IEnumerable<string> Errors { get; private set; } = Enumerable.Empty<string>();
        #endregion

        #region Constructor
        public ResultModel(bool success, dynamic? resultData, IEnumerable<string> errors)
        {
            Success = success;
            ResultData = resultData;
            Errors = errors;
        }

        private ResultModel()
        {
        }
        #endregion

        #region Public Methods

        #region Get Result Data
        public T? GetResultData<T>() => $"{ResultData}".ToObject<T>();
        #endregion

        #region With Success
        public static ResultModel WithSuccess()
        {
            return new ResultModel() { Success = true };
        }

        public static ResultModel WithSuccess(dynamic? resultData)
        {
            return new ResultModel() { Success = true, ResultData = resultData };
        }
        #endregion

        #region With Error
        public static ResultModel WithError(string errorMessage)
        {
            return new ResultModel() { Success = false, Errors = [errorMessage] };
        }
        #endregion

        #region With Errors
        public static ResultModel WithErrors(IEnumerable<string> errors)
        {
            return new ResultModel() { Success = false, Errors = errors };
        }
        #endregion

        #endregion
    }
}
