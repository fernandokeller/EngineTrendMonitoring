using EngineTrendMonitoring.Api.Core.Services.Aircraft;
using EngineTrendMonitoring.Shared.Models.Aircraft.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EngineTrendMonitoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        #region Properties
        private readonly IAircraftService _aircraftService;
        #endregion

        #region Constructor
        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }
        #endregion

        #region GET - Get By Id Async
        /// <summary>
        /// Get Aircraft By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id) 
            => Ok(await _aircraftService.GetByIdAsync(id));
        #endregion

        #region POST - Get Async
        /// <summary>
        /// Get Aircrafts By Filter
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Get")]
        public async Task<IActionResult> GetAsync(GetAircraftRequestModel requestModel)
            => Ok(await _aircraftService.GetAsync(requestModel));
        #endregion

        #region POST - Create Async
        /// <summary>
        /// Create Aircraft
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(CreateAircraftRequestModel requestModel) 
            => Ok(await _aircraftService.CreateAsync(requestModel));
        #endregion

        #region PUT - Edit Async
        /// <summary>
        /// Edit Aircraft
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditAsync(EditAircraftRequestModel requestModel) 
            => Ok(await _aircraftService.EditAsync(requestModel));
        #endregion

        #region DELETE - Delete Async
        /// <summary>
        /// Delete Aircraft
        /// </summary>
        /// <param name="id">Aircraft Id</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id) 
            => Ok(await _aircraftService.DeleteAsync(id));
        #endregion
    }
}
