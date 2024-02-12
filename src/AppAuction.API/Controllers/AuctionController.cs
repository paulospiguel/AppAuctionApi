using Microsoft.AspNetCore.Mvc;
using AppAuction.API.UseCases.Auctions.GetCurrent;
using AppAuction.API.Entities;

namespace AppAuction.API.Controllers;

public class AuctionController : AppAuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuctions()
    {
        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        if(result is null) return NoContent();

        return Ok(result);
    }
}