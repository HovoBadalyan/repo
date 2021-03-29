using NorthWnd.CORE.Enum;


namespace NorthWnd.CORE.BusinessModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
