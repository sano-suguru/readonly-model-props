using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace readonly_model_props {
  class Program {
    static void Main(string[] args) {
      /* DB 生成 */
      using (var context = new InMemoryDbContext()) {
        context.Database.EnsureCreated();
      }

      Console.WriteLine("* ==========READ========== *");
      using (var context = new InMemoryDbContext()) {
        var books = context.Books.AsNoTracking().AsEnumerable();
        foreach (var book in books) {
          Console.WriteLine($"{book.Id} {book.Title} {book.Author}");
        }
      }

      Console.WriteLine("* ==========UPDATE========== *");
      using (var context = new InMemoryDbContext()) {
        var target = context.Books
          .AsNoTracking()
          .Single(b => b.Id == 1);
        context.Books.Update(
          new Book(
            id: target.Id,
            title: target.Title,
            author: "今井 勝信"
          )
        );
        context.SaveChanges();

        var updated = context.Books.AsNoTracking().Single(b => b.Id == 1);
        Console.WriteLine($"{updated.Id} {updated.Title} {updated.Author}");
      }
    }
  }
}
