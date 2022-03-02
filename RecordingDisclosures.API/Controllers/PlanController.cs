using Microsoft.AspNetCore.Mvc;
using RecordingDisclosures.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using RecordingDisclosures.Domain;

namespace RecordingDisclosures.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly ILogger<PlanController> _logger;
        private readonly IQuery _query;
        public PlanController(ILogger<PlanController> logger, IQuery query)
        {
            _logger = logger;
            _query = query;
        }

        [HttpGet("GetPlans")]
        public List<PlanItem> GetPlans()
        {
            List<PlanItem> item = new List<PlanItem>();
            try
            {
                _logger.LogInformation("Start GetPlans");

                item = _query.ListPlans();

                _logger.LogInformation("End GetPlans");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return item;
        }
    }
}
