﻿namespace mockTest2.Models;

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<DriverCompetition> DriverCompetitions { get; set; } 
}
