namespace Task4
{
	class Book
	{
		public string Title;
		public string Author;
		public string ISBN;
		public bool Availability;

		
		public Book(string title, string author, string isbn)
		{
			Title = title;
			Author = author;
			ISBN = isbn;
			Availability = true; 
		}
	}

	class Library
	{
		List<Book> books = new List<Book>();
		public void AddBook(Book book)
		{
			books.Add(book);
			Console.WriteLine("Book added");
		}

		public void SearchBook(string input)
        {
            bool found = false;

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == input || books[i].Author == input)
                {
                    Console.WriteLine("Book is found");
					found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("Book not found");
            }
        }


		public void BorrowBook(string isbn)
		{
			bool found = false;

			for (int i = 0; i < books.Count; i++)
			{
				if (books[i].ISBN == isbn)
				{
					found = true;

					if (books[i].Availability == true)
					{
						books[i].Availability = false;
						Console.WriteLine("Book borrowed");
					}
					else
					{
						Console.WriteLine("Book is already borrowed by another one");
					}
				}
			}

			if (found == false)
			{
				Console.WriteLine("Book not found");
			}
		}


		public void ReturnBook(string isbn)
		{
			bool found = false;

			for (int i = 0; i < books.Count; i++)
			{
				if (books[i].ISBN == isbn)
				{
					found = true;

					if (books[i].Availability == false)
					{
						books[i].Availability = true;
						Console.WriteLine("Book returned");
					}
					else
					{
						Console.WriteLine("Book is not borrowed");
					}
				}
			}

			if (found == false)
			{
				Console.WriteLine("Book not found");
			}
		}



	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Library library = new Library();

			while (true)
			{
				Console.WriteLine("\n==== Library Menu ====");
				Console.WriteLine("1 - Add Book");
				Console.WriteLine("2 - Search Book");
				Console.WriteLine("3 - Borrow Book");
				Console.WriteLine("4 - Return Book");
				Console.WriteLine("5 - Exit");

				Console.Write("Enter your choice: ");
				string choice = Console.ReadLine();

				if (choice == "1")
				{
					Console.Write("Title: ");
					string title = Console.ReadLine();

					Console.Write("Author: ");
					string author = Console.ReadLine();

					Console.Write("ISBN: ");
					string isbn = Console.ReadLine();

					Book book = new Book(title, author, isbn);
					library.AddBook(book);
				}
				else if (choice == "2")
				{
					Console.Write("Enter Title or Author: ");
					string input = Console.ReadLine();
					library.SearchBook(input);
				}
				else if (choice == "3")
				{
					Console.Write("Enter ISBN: ");
					string isbn = Console.ReadLine();
					library.BorrowBook(isbn);
				}
				else if (choice == "4")
				{
					Console.Write("Enter ISBN: ");
					string isbn = Console.ReadLine();
					library.ReturnBook(isbn);
				}
				
				else if (choice == "5")
				{
					break;
				}
				else
				{
					Console.WriteLine("Invalid choice");
				}
			}
		}
	
	}
}
