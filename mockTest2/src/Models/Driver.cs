using System.ComponentModel.DataAnnotations;

namespace mockTest2.Models;

public class Driver
{
    public int Id { get; set; }
    
    [Required]
    [Length(1, 200)]
    public required string FirstName { get; set; }
    
    [Required]
    [Length(1, 200)]
    public required string LastName { get; set; }
    
    [Required]
    public required DateTime Birthday { get; set; }
    
    [Required]
    public int CarId { get; set; }
    
    public Car Car { get; set; }
    
    [Timestamp]
    public byte[] ConcurrencyToken { get; set; }
}
