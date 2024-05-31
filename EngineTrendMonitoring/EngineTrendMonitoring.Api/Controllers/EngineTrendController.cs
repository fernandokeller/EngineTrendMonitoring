using EngineTrendMonitoring.Api.Core.Services.EngineTrend;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EngineTrendMonitoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineTrendController : ControllerBase
    {
        #region Properties
        private readonly IEngineTrendService _engineTrendService;
        #endregion

        #region Constructor
        public EngineTrendController(IEngineTrendService engineTrendService)
        {
            _engineTrendService = engineTrendService;
        }
        #endregion

        #region GET - Get By Id Async
        /// <summary>
        /// Get Engine Trend By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id) 
            => Ok(await _engineTrendService.GetByIdAsync(id));
        #endregion

        #region POST - Get Async
        /// <summary>
        /// Get Engine Trend By Filter
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetAsync(GetEngineTrendRequestModel requestModel) 
            => Ok(await _engineTrendService.GetAsync(requestModel));
        #endregion

        #region POST - Create Async
        /// <summary>
        /// Create Engine Trend
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(CreateEngineTrendRequestModel requestModel) 
            => Ok(await _engineTrendService.CreateAsync(requestModel));
        #endregion

        #region PUT - Edit Async
        /// <summary>
        /// Edit Engine Trend
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(EditEngineTrendRequestModel requestModel) 
            => Ok(await _engineTrendService.EditAsync(requestModel));
        #endregion

        #region DELETE - Delete Async
        /// <summary>
        /// Delete Engine Trend By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id) 
            => Ok(await _engineTrendService.DeleteAsync(id));
        #endregion
    }
}
