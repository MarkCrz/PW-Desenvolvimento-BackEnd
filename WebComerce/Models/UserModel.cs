using WebComerce.Models.Enums;

namespace WebComerce.Models;

public class UserModel
{
    public  int id { get; set; }
    public string Username { get; set; } = string.Empty;
    
    public byte[] PasswordHash { get; set; }
    
    public byte[] PasswordSalt { get; set; }
    public Admin admin { get; set; }
}