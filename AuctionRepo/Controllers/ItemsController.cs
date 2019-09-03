using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionRepo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuctionRepo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IListItems _listItems;
        private readonly IWinner _winner;
        private readonly ILogger _logger;

        public ItemsController(IListItems listItems, IWinner winner, ILogger<ItemsController> loggerFactory)
        {
            _logger = loggerFactory;
            _listItems = listItems;
            _winner = winner;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Calling itemsGet");
            return Ok(_listItems.ListAllItem());
        }

        [Route("[action]/{itemID}")]
        [HttpGet]
        public IActionResult GetWinner(int itemID)
        {
            return Ok(_winner.Calculate(itemID));
        }
    }
}