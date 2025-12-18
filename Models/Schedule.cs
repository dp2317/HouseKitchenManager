using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseKitchenManager.Models;

[Table("Schedules")]
public class Schedule
{
    [Key]
    public int Id { get; set; }

    public int MemberId { get; set; }
    public DateTime CookDate { get; set; }
}
