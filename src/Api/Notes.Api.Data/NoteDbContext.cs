using Microsoft.EntityFrameworkCore;
using Notes.Api.Entities;

namespace Notes.Api.Data;

public class NoteDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly string _connectionStr;

    public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) => Database.EnsureCreated();

    public NoteDbContext(string connectionStr)
    {
        _connectionStr = connectionStr;
        Database.EnsureCreated();
    }

    public NoteDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>()
            .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(100);

        modelBuilder.Entity<Note>()
            .Property(n => n.Content)
            .IsRequired();

        modelBuilder.Entity<User>()
            .Property(n => n.NickName)
                .IsRequired()
                .HasMaxLength(100);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionStr);
    }
}
