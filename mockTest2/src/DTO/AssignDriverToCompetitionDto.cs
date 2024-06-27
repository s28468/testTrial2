using System.ComponentModel.DataAnnotations;

namespace mockTest2.DTO
{
    public class AssignDriverToCompetitionDto
    {
        public int DriverId { get; set; }
        public int CompetitionId { get; set; }
        public DateTime Date { get; set; }
    }
}
