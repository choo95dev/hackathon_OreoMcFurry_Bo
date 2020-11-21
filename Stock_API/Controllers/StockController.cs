using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_API.Application.Services.Stock.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : MediatRController
    {
        #region Get Methods
        [HttpGet("Stocks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStockValue()
        {
            var result = await Mediator.Send(new GetStockValueByIntervalQuery());
            return Ok(result);
        }
        #endregion
    }
}
