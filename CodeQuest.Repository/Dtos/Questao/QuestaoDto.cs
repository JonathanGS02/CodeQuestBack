using CodeQuest.Domain.Identity;
using CodeQuest.Repository.Dtos.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Repository.Dtos.Questao
{
    public class QuestaoDto
    {
        public Guid QuestaoId { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Pergunta1 { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Pergunta2 { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Pergunta3 { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Pergunta4 { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
        public string Pergunta5 { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(4, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no minimo 50 caracteres.")]
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
        public int UserId { get; set; }
        public int Numero { get; set; }
        public double Exp { get; set; }
    }
}
