using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseKitchenManager.Models;

[Table("Ratings")]
public class Rating
{
    [Key]
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    // ✅ MUST MATCH CONTROLLERS
    public int RaterMemberId { get; set; }

    public int Stars { get; set; }
}
