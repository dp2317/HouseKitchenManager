using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseKitchenManager.Models;

[Table("Members")]
public class Member
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ColorHex { get; set; }
}
