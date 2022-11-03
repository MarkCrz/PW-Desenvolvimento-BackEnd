using WebComerce.Models.Enums;

namespace WebComerce.Models;

public class UserModel
{
    public  int id { get; set; }
    public string Username { get; set; }
    
    public string password { get; set; }
    
    public Admin admin { get; set; }
}