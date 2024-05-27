//importing system and sqlclient namespaces
using System;
using System.Data.SqlClient;


namespace BookConsoleApp
{
    class Program
    {
        //connection string of the book
        static string connectionString = "Server=ZEROCOOL;Database=Books;Integrated Security=True;";


        //main function
        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.WriteLine("1. Insert a new book");
                Console.WriteLine("2. Display all books");
                Console.WriteLine("3. Update a book");
                Console.WriteLine("4. Delete a book");
                Console.WriteLine("5. Exit");
                Console.Write("\nChoose an operation:");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        InsertBook();
                        break;
                    case "2":
                        ReadBooks();
                        break;
                    case "3":
                        UpdateBook();
                        break;
                    case "4":
                        DeleteBook();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }

        static void InsertBook()
        {
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter author: ");
            var author = Console.ReadLine();
            Console.Write("Enter published year: ");
            var year = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Bookdata (Title, Author, Year) VALUES (@Title, @Author, @Year)", connection);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@Year", year);
                command.ExecuteNonQuery();
            }

            Console.WriteLine("\nBook inserted successfully.\n");
        }

        static void ReadBooks()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Bookdata", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"\nID: {reader["BookId"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Published Year: {reader["Year"]}\n");
                    }
                }
            }
        }

        static void UpdateBook()
        {
            Console.Write("\nEnter the ID of the book to update: ");
            var id = int.Parse(Console.ReadLine());

            Console.Write("Enter new title: ");
            var title = Console.ReadLine();
            Console.Write("Enter new author: ");
            var author = Console.ReadLine();
            Console.Write("Enter new published year: ");
            var year = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Bookdata SET Title = @Title, Author = @Author, Year = @Year WHERE BookId = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                command.Parameters.AddWithValue("@Year", year);
                command.ExecuteNonQuery();
            }

            Console.WriteLine("\nBook updated successfully.\n");
        }

        static void DeleteBook()
        {
            Console.Write("\nEnter the ID of the book to delete: ");
            var id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Bookdata WHERE BookId = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }

            Console.WriteLine("\nBook deleted successfully.\n");
        }
    }
}
