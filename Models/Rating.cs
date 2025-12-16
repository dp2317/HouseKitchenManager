namespace HouseKitchenManager.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public int FromMemberId { get; set; }
        public int Stars { get; set; }
    }
}
