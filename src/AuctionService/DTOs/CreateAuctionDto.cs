using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTOs;

public class CreateAuctionDto
{  
    [Required]
    public string Type { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public string Condition { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public int ReservePrice { get; set;} 
    [Required]
    public DateTime AuctionEnd { get; set; }
}
