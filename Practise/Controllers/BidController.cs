using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practise.Interfaces;
using Practise.Models;

namespace Practise.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBiddings _biddings;
        private readonly IListBiddings _listBiddings;

        public BidController(IBiddings biddings, IListBiddings listBiddings)
        {
            _biddings = biddings;
            _listBiddings = listBiddings;
        }

        [Route("[action]")]
        [HttpPost]
        [EnableCors]
        //[ActionName("Bid")]
        public ActionResult Bid([FromForm] BidRequest bid)
        {
            return Ok(_biddings.Bid(bid));
        }

        [Route("[action]/{ItemID}")]
        [HttpGet]
        public IActionResult GetBiddings(int ItemID)
        {
            return Ok(_listBiddings.GetList(ItemID));
        }
    }
}