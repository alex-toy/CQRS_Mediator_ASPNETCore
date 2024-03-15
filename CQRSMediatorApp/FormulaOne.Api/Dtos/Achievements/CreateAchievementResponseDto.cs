namespace FormulaOne.Api.Dtos.Achievements
{
    public class CreateAchievementResponseDto
    {
        public Guid DriverId { get; set; }
        public int WorldChampionship { get; set; }
        public int FastestLap { get; set; }
        public int PolePosition { get; set; }
        public int RaceWins { get; set; }
    }
}
