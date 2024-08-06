using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class FPTManagementDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public FPTManagementDbContext(DbContextOptions<FPTManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Annotation
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.PersonRole)
                      .HasConversion(
                          v => v.ToString(),
                          v => (Person.Role)Enum.Parse(typeof(Person.Role), v))
                      .HasDefaultValue(Person.Role.Student);
            });
            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.PersonRole)
                      .HasConversion(
                          v => v.ToString(),
                          v => (Person.Role)Enum.Parse(typeof(Person.Role), v))
                      .HasDefaultValue(Person.Role.Professor);
            });
            modelBuilder.Entity<Address>().HasNoKey();
            #endregion
            modelBuilder.Init();
        }
    }

    public static class SeedData
    {
        public static void Init(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Student1", Phone = "0123456789", Email = "student1@example.com", Gpa = 3.5f, PersonRole = Person.Role.Student },
                new Student { Id = 2, Name = "Student1", Phone = "0223456789", Email = "student2@example.com", Gpa = 3.5f, PersonRole = Person.Role.Student },
                new Student { Id = 3, Name = "Student1", Phone = "0323456789", Email = "student3@example.com", Gpa = 3.5f, PersonRole = Person.Role.Student },
                new Student { Id = 4, Name = "Student1", Phone = "0423456789", Email = "student4@example.com", Gpa = 3.5f, PersonRole = Person.Role.Student },
                new Student { Id = 5, Name = "Student1", Phone = "0523456789", Email = "student5@example.com", Gpa = 3.5f, PersonRole = Person.Role.Student }

            );
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 1, Name = "Professor1", Phone = "0987654321", Email = "professor1@example.com", Salary = 5000, PersonRole = Person.Role.Professor },
                new Professor { Id = 2, Name = "Professor2", Phone = "0987654321", Email = "professor2@example.com", Salary = 5000, PersonRole = Person.Role.Professor },
                new Professor { Id = 3, Name = "Professor3", Phone = "0987654321", Email = "professor3@example.com", Salary = 5000, PersonRole = Person.Role.Professor },
                new Professor { Id = 4, Name = "Professor4", Phone = "0987654321", Email = "professor4@example.com", Salary = 5000, PersonRole = Person.Role.Professor },
                new Professor { Id = 5, Name = "Professor5", Phone = "0987654321", Email = "professor5@example.com", Salary = 5000, PersonRole = Person.Role.Professor }
            );
        }
    }
}
