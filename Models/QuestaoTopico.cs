using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models
{
    public class QuestaoTopico
    {
        [Key]
        [Required]
        public Guid QuestaoTopicoId { get; set; }
        [Required]
        public Guid QuestaoId { get; set; }
        public virtual Questao Questao { get; set; }
        [Required]
        public Guid TopicoId { get; set; }
        public virtual Topico Topico { get; set; }
    }
}
