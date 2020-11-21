using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock_API.Application.Services.Leaderboard.Command;
using Stock_API.Application.Services.Leaderboard.Query;

namespace Stock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerScoreController : MediatRController
    {
        #region Get Methods
        [HttpGet("Scores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStockValue()
        {
            var result = await Mediator.Send(new GetPlayerScores());
            return Ok(result);
        }        
        [HttpGet("{SessionID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPlayerScore([FromRoute]string SessionID)
        {
            var result = await Mediator.Send(new GetPlayerScoreBySessionID
            {
                SessionID = SessionID
            });
            return Ok(result);
        }
        #endregion

        #region Create / Update 
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePlayerScore(CreatePlayerScore command)
        {
            var result = await Mediator.Send(command);

            if(result != null)
            {
                return Ok();
            }
            return BadRequest();
        }        
        
        [HttpPatch("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePlayerScore(UpdatePlayerScore command)
        {
            var result = await Mediator.Send(command);

            if(result != null)
            {
                return Ok();
            }
            return BadRequest();
        }
        #endregion
    }
}
