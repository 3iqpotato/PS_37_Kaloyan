using Microsoft.EntityFrameworkCore;
using Welcome.Model;
using Welcome.Others;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=users.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Names = "Иван Иванов", Password = "123456", Email = "i.ivanov@gmail.com", FacultyNumber = "F12345", Age = 20, Role = UserRolesEnum.ADMIN, Expires = DateTime.Now.AddYears(1) },
            new User { Id = 2, Names = "Student2", Password = "123", Email = "student2@gmail.com", FacultyNumber = "F54321", Age = 19, Role = UserRolesEnum.STUDENT, Expires = DateTime.Now.AddDays(30) },
            new User { Id = 3, Names = "Teacher", Password = "1234", Email = "teacher@gmail.com", FacultyNumber = "T99999", Age = 35, Role = UserRolesEnum.PROFESSOR, Expires = DateTime.Now.AddDays(30) },
            new User { Id = 4, Names = "Admin", Password = "12345", Email = "admin@gmail.com", FacultyNumber = "A00001", Age = 25, Role = UserRolesEnum.ADMIN, Expires = DateTime.Now.AddYears(1) }
        );
    }
}