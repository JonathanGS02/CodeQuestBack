using CodeQuest.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace CodeQuest.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string? Descricao { get; set; }
        public Funcao Funcao { get; set; }
        public string? Imagem { get; set; }
        public double Exp { get; set; }
        public int Nivel { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
