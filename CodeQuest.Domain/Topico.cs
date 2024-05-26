using CodeQuest.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Domain
{
    public class Topico
    {
        [Key]
        [Required]
        public Guid TopicoId { get; set; }
        public virtual IEnumerable<Questao> Questoes { get; set; }
        [Required]
        public int Nivel { get; set; }
        public int QtdQuestoes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
