namespace mockTest2.Models;
using System.ComponentModel.DataAnnotations;

public class CarManufacturer
{
    public int Id { get; set; }
    [Required]
    [Length(1, 200)]
    public string Name { get; set; }
}