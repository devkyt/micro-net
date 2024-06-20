using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Items")]
public class Item 
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public string Condition { get; set; }
    public string ImageUrl { get; set; }

    // nav properties
    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }
}
