namespace mockTest2.Models;

public class DriverCompetition
{
    public int DriverId { get; set; }
    public Driver Driver { get; set; }
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; }
    public DateTime Date { get; set; }
}