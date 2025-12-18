using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseKitchenManager.Models;

[Table("Notifications")]
public class Notification
{
    [Key]
    public int Id { get; set; }

    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
}
