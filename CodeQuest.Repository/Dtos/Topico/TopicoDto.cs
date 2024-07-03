using CodeQuest.Domain.Identity;
using CodeQuest.Repository.Dtos.Questao;
using CodeQuest.Repository.Dtos.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Dtos.Topico
{
    public class TopicoDto
    {
        public Guid TopicoId { get; set; }
        public IEnumerable<QuestaoDto> Questoes { get; set; }
        public QuestaoDto Questao { get; set; }
        [Required]
        public int Nivel { get; set; }
        public int QtdQuestoes { get; set; }
        public int UserId { get; set; }
        public int Numero { get; set; }
    }
}
