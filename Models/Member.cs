namespace HouseKitchenManager.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // 🔐 Login credentials
        public string Username { get; set; }
        public string Password { get; set; }

        // 🌈 UI color
        public string ColorHex { get; set; } = "#0d6efd";
    }
}
