using Microsoft.AspNetCore.Identity;

namespace WebAPI.Dominio
{
    public class User : IdentityUser<int>
    {
        public string NomeCompleto { get; set; }
        public string Member { get; set; } = "Member";
        public int? OrgId { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}