using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Models
{
    public class Questao
    {
        [Key]
        [Required]
        public Guid QuestaoId { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Titulo { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Pergunta1 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength (100)]
        public string Pergunta2 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Pergunta3 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Pergunta4 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Pergunta5 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Pergunta6 { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public Boolean PerguntaCorreta1 { get; set; }
        [Required]
        public Boolean PerguntaCorreta2 { get; set; }
        [Required]
        public Boolean PerguntaCorreta3 { get; set; }
        [Required]
        public Boolean PerguntaCorreta4 { get; set; }
        [Required]
        public Boolean PerguntaCorreta5 { get; set; }
        [Required]
        public Boolean PerguntaCorreta6 { get; set; }
        [Required]
        public int Nivel {  get; set; }
        [Required]
        public Boolean Concluido { get; set; }
    }
}
