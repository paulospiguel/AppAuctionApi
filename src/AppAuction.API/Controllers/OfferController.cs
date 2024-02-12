using Microsoft.AspNetCore.Mvc;
using AppAuction.API.Entities;
using AppAuction.API.Comminication.Requests;
using AppAuction.API.Filters;

namespace AppAuction.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribuite))]

public class OfferController : AppAuctionBaseController
{
    [HttpPost]
    [Route("{ItemId}")]
    [ProducesResponseType(typeof(Item), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult CreateOffer([FromRoute]int ItemId, [FromBody] CreateOfferRequestJson request) 
    {
        return Created();
    }
}