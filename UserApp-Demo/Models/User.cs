using Microsoft.AspNetCore.Identity;

namespace UserApp_Demo.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string? EmailOtp { get; set; }
        public DateTime? OtpExpiryTime { get; set; }
    }
}
