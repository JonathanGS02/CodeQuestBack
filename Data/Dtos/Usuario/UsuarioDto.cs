using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Data.Dtos.Usuario
{
    public class UsuarioDto
    {
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
    }
}
