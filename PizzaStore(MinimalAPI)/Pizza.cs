using Microsoft.EntityFrameworkCore;

namespace PizzaStore_MinimalAPI_
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    class PizzaDb : DbContext
    {
        public PizzaDb(DbContextOptions option) : base(option) { }
        public DbSet<Pizza> Pizzas { get; set; } = null!;

    }
}
