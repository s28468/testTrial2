namespace mockTest2.Models;
using System.ComponentModel.DataAnnotations;

public class Competition
{
    public int Id { get; set; }
    [Required]
    [Length(1, 200)]
    public string Name { get; set; }
}
