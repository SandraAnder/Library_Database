using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

class Book
{
    public string? BTitel { get; set; }
    public string? Creator { get; set; }
    public string? Genre { get; set;}
}

class Program
{
    static List<Book> GetBooks()
    {
        string connectionString = "server=localhost;database=bibliotek;uid=root;pwd=;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT M.Title AS BTitel, CONCAT(C.FName, ' ', C.LName) AS Author, G.Name AS Genre " +
                           "FROM creatorToMedia CM " +
                           "INNER JOIN media M ON CM.MediaId = M.Id " +
                           "INNER JOIN genre G ON M.genreId = G.id " +
                           "INNER JOIN creators C ON CM.CreatorId = C.Id " +
                           "WHERE M.id = 2";

            var books = connection.Query<Book>(query).ToList();

           return books;
        }
    }

    static void Main(string[] args)
    {
        var books = GetBooks();
        
        // Skriver ut informationen Title och författare
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.BTitel}, Creator: {book.Creator}, Genre: {book.Genre}");
        }
    }
}