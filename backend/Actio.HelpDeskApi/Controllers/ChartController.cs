using Actio.HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ChartController : ControllerBase
    {
        public readonly IChartService _chartService;
        public ChartController(IChartService chartService)
        {
            _chartService = chartService;
        }
        [HttpGet("chartPercentage")]
        public async Task<ActionResult> Get()
        {
            var resposta = await _chartService.GetModel();

            return Ok(resposta);
        }
    }
}
