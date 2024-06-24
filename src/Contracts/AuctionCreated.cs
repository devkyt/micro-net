namespace Contracts;

public class AuctionCreated
{
    public Guid Id { get; set; }
    public int ReservePrice { get; set;} 
    public string Seller { get; set; }
    public string Winner { get; set; }
    public int SoldAmount { get; set; }
    public int CurrentHighBid { get; set; }
    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; } 
    public DateTime AuctionEnd { get; set; }
    public string Status { get; set; } 
    public string Type { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    public string Condition { get; set; }
    public string ImageUrl { get; set; }
}