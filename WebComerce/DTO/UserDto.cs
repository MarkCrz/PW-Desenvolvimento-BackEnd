using WebComerce.Models.Enums;

namespace WebComerce.DTO;

public class UserDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Admin Admin { get; set; }
}