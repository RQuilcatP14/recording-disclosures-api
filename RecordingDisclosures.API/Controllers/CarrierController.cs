using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecordingDisclosures.Domain;
using RecordingDisclosures.Interfaces;

namespace RecordingDisclosures.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarrierController : ControllerBase
    {
        private readonly ILogger<PlanController> _logger;
        private readonly IPersistence _persistence;
        private readonly IQuery _query;
        public CarrierController(ILogger<PlanController> logger, IPersistence persistence, IQuery query)
        {
            _logger = logger;
            _persistence = persistence;
            _query = query;
        }

        [HttpGet("GetCarriers")]
        public List<CarrierItem> GetCarriers()
        {
            List<CarrierItem> item = new List<CarrierItem>();
            try
            {
                _logger.LogInformation("Start GetCarriers");

                item = _query.ListCarriers();

                _logger.LogInformation("End GetCarriers");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return item;
        }

        [HttpPost("AddRecordingDisclosure")]
        public string AddRecordingDisclosure([FromBody] CarrierPlanItem request)
        {
            try
            {
                _logger.LogInformation("Start AddRecordingDisclosure");
                _persistence.InsertCarrierPlan(request);
                _logger.LogInformation("End AddRecordingDisclosure");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return "Success";
        }
    }
}
