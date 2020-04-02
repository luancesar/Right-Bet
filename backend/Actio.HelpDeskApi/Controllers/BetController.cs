using Actio.HelpDeskApi.Models;
using Actio.HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BetController : ControllerBase
    {

        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost()]
        public async Task<ActionResult> Bet(BetModel bet)
        {
            var resposta = await _betService.Bet(bet);

            return Ok(resposta);
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var resposta = await _betService.GetBets();

            return Ok(resposta.ToArray().OrderByDescending(b => b.Date));
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(BetModel bet)
        {
            var resposta = await _betService.Delete(bet.Id);

            return Ok(resposta);
        }

        [HttpPost("downloadReport")]
        public async Task<ActionResult> DownloadFile(FileModel model)
        {
            if (string.IsNullOrEmpty(model.Endereco))
                return BadRequest();

            var fileInfo = await _betService.DownloadFile(model.Endereco);

            var image = ((new ImageConverter()).ConvertFrom(fileInfo));
            if (fileInfo != null)
                return Ok(fileInfo);
                //return Ok(image);
            else
                return BadRequest();
        }
    }
}
