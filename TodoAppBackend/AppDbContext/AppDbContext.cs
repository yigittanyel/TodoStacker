using Microsoft.EntityFrameworkCore;
using TodoAppBackend.Models;

namespace TodoAppBackend.ApplicationDbContext;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem
            {
                Id = 1,
                Title = "Todo Item 1",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 2,
                Title = "Todo Item 2",
                IsCompleted = false
            },
            new TodoItem
            {
                Id = 3,
                Title = "Todo Item 3",
                IsCompleted = false
            } 
            );
    }
}
