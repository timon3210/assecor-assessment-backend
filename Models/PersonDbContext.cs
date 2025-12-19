using Microsoft.EntityFrameworkCore;

namespace AssecorAssessment;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=persons.db");
    }
}