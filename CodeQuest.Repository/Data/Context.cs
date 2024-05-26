using CodeQuest.Domain;
using CodeQuest.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeQuest.Repository.Data
{
    public class Context : IdentityDbContext<User, Role, int, 
                                            IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                            IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Context(DbContextOptions<Context> opt) : base(opt) { }

        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<QuestaoTopico> QuestaoTopicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            //modelBuilder.Entity<QuestaoTopico>()
            //    .HasKey(QT => new { QT.QuestaoId, QT.TopicoId });

            //modelBuilder.Entity<Topico>()
            //    .HasMany(t => t.Questoes)
            //    .WithOne(q => q.Topico)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
