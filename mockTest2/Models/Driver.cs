namespace mockTest2.Models;

public class Driver
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public ICollection<DriverCompetition> DriverCompetitions { get; set; } 
}
