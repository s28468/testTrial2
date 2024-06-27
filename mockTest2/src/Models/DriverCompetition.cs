using System.ComponentModel.DataAnnotations;

namespace mockTest2.Models;

public class DriverCompetition
{
    [Required]
    public int DriverId { get; set; }

    public Driver Driver { get; set; }

    [Required]
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    [Timestamp]
    public byte[] ConcurrencyToken { get; set; }
}