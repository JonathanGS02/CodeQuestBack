using CodeQuest.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public Guid UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Guid Senha { get; set; }
        [Required]
        public int Nivel { get; set; }
        [Required]
        public int Ponto { get; set; }
        public Funcao Funcao { get; set; }
    }
}
