namespace ecommerco_proj.DTOs.Account
{
    public class NewUserDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public List<string?> roles { get; set; }
        public string? Token { get; set; }
    }
}
