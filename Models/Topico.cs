using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models
{
    public class Topico
    {
        [Key]
        [Required]
        public Guid TopicoId { get; set; }
        public IEnumerable<Questao> Questoes { get; set; }
        [Required]
        public int Nivel { get; set; }
        public int QtdQuestoes { get; set; }
    }
}
