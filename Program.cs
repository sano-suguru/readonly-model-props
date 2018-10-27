using System;
using System.Linq;

namespace readonly_model_props {
  class Program {
    static void Main(string[] args) {
      using (var context = new InMemoryDbContext()) {
        context.Database.EnsureCreated();
      }

      using (var context = new InMemoryDbContext()) {
        var books = context.Books.AsEnumerable();
        foreach (var book in books) {
          Console.WriteLine($"{book.Id} {book.Title} {book.Author}");
        }
      }
    }
  }
}
