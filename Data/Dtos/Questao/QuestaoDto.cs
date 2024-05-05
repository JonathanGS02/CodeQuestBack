using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Data.Dtos.Questao
{
    public class QuestaoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Pergunta1 { get; set; }
        [Required]
        public string Pergunta2 { get; set; }
        [Required]
        public string Pergunta3 { get; set; }
        [Required]
        public string Pergunta4 { get; set; }
        [Required]
        public string Pergunta5 { get; set; }
        [Required]
        public string Pergunta6 { get; set; }
        [Required]
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
        public int Nivel { get; set; }
        [Required]
        public Boolean Concluido { get; set; }
    }
}
