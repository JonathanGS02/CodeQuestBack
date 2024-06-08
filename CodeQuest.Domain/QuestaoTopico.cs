using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Domain
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
        public int Numero { get; set; }

    }
}
