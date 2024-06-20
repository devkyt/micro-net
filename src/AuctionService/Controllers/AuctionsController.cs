using AuctionService.Data;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/actions")]
public class AuctionsController : ControllerBase
{
    private readonly AuctionDbContext _context;
    private readonly IMapper _mapper;
    public AuctionsController(AuctionDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<AuctionDto>> CreateAuction(CreateAuctionDto auctionDto)
    {
        var auction = _mapper.Map<Auction>(auctionDto);
        // TODO: add current user as a seller

        auction.Seller = "wizard";

        _context.Auctions.Add(auction);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Could not save changes to the DB");

        return CreatedAtAction(nameof(GetAuctionById), new { auction.Id }, _mapper.Map<AuctionDto>(auction));
    }

    [HttpGet]
    public async Task<ActionResult<List<AuctionDto>>> GetAllAuctions()
    {
        var auctions = await _context.Auctions
                                     .Include(x => x.Item)
                                     .OrderBy(x => x.Item.Type)
                                     .ToListAsync();

        return _mapper.Map<List<AuctionDto>>(auctions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuctionDto>> GetAuctionById(Guid id)
    {
        var auction = await _context.Auctions
                                    .Include(x => x.Item)
                                    .FirstOrDefaultAsync(x => x.Id == id);

        if (auction == null) return NotFound();

        return _mapper.Map<AuctionDto>(auction);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuctionById(Guid id, UpdateAuctionDto updateAuctionDto)
    {
        var auction = await _context.Auctions
                                    .Include(x => x.Item)
                                    .FirstOrDefaultAsync(x => x.Id == id);

       if (auction == null) return NotFound();

       auction.Item.Type = updateAuctionDto.Type ?? auction.Item.Type;
       auction.Item.Model = updateAuctionDto.Model ?? auction.Item.Model;
       auction.Item.Color = updateAuctionDto.Color ?? auction.Item.Color;
       auction.Item.Year = updateAuctionDto.Year ?? auction.Item.Year;
       auction.Item.Condition = updateAuctionDto.Condition ?? auction.Item.Condition;

       var result = await _context.SaveChangesAsync() > 0;

       if (!result) return BadRequest("Could not save changes");

       return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuctionById(Guid id)
    {
        var auction = await _context.Auctions.FindAsync(id);

        if (auction == null) return NotFound();

        // TO: check seller equal to username

        _context.Auctions.Remove(auction);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return BadRequest("Could not delete the auction");

        return Ok();
    }
}
