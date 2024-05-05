using CodeQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Data.Login
{
    public class LoginContext:DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options) { }
        public DbSet<Cadastro> cadastros { get; set; }
    }
}
