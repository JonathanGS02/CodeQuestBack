using CodeQuest.Data.Login;
using CodeQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Data
{
    public class CodeQuestContext:DbContext
    {
        public CodeQuestContext(DbContextOptions<CodeQuestContext> options)
            : base(options) { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Topico> Topico { get; set; }
        public DbSet<QuestaoTopico> QuestaoTopico { get; set; }
        public DbSet<UsuarioTopico> UsuarioTopico { get; set; }
    }
}

