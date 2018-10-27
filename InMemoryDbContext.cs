using Microsoft.EntityFrameworkCore;

namespace readonly_model_props {
  class InMemoryDbContext : DbContext {
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
      optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryDatabase");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Book>(book => {
        book.HasKey(nameof(Book.Id));
        book.Property(e => e.Title);
        book.Property(e => e.Author);
      });
      modelBuilder.Entity<Book>().HasData(
        new Book(id: 1, title: "Flutter入門", author: "掌田 津耶乃"),
        new Book(id: 2, title: "Nuxt.jsビギナーズガイド", author: "花谷 拓磨"),
        new Book(id: 3, title: "IntelliJ IDEAハンズオン", author: "山本 裕介")
      );
    }
  }
}
