using System;

namespace HouseKitchenManager.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime? CookDate { get; set; }
    }
}
