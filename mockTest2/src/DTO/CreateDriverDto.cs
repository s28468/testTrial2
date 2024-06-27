using System.ComponentModel.DataAnnotations;

namespace mockTest2.DTO;

public class CreateDriverDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public int CarId { get; set; }
}