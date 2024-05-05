using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models
{
    public class UsuarioTopico
    {
        [Key]
        [Required]
        public Guid UsuarioTopicoId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [Required]
        public Guid TopicoId { get; set; }
        public virtual Topico Topico { get; set; }
    }
}
