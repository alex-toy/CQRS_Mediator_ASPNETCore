namespace FormulaOne.Entities.Dtos.Achievements
{
    public class CreateAchievementRequestDto
    {
        public Guid DriverId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePosition { get; set; }
        public int RaceWins { get; set; }
    }
}
