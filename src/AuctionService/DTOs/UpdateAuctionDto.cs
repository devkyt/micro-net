namespace AuctionService.DTOs;

public class UpdateAuctionDto
{
    public string Type { get; set; }
    public string Model { get; set; }
    public int? Year { get; set; }
    public string Color { get; set; }
    public string Condition { get; set; }
}
