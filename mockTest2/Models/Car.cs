namespace mockTest2.Models;

public class Car
{
    public int Id { get; set; }
    public string ModelName { get; set; }
    public int Number { get; set; }
    public int CarManufacturerId { get; set; }
    public CarManufacturer CarManufacturer { get; set; }
}