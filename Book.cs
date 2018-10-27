﻿namespace readonly_model_props {
  class Book {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }

    public Book(int id, string title, string author) {
      Id = id;
      Title = title;
      Author = author;
    }
  }
}
