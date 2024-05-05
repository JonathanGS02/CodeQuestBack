using CodeQuest.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeQuest.Data
{
    public class TopicoDto
    {
        public IEnumerable<Questao> Questoes { get; set; }
        [Required]
        public int Nivel { get; set; }
        public int QtdQuestoes { get; set; }
    }
}
