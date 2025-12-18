using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Ratings")]
public class Rating
{
    [Key]
    public int Id { get; set; }

    public int ScheduleId { get; set; }
    public int RaterMemberId { get; set; }
    public int Stars { get; set; }
}
