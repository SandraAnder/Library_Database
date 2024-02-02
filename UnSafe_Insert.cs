
/*

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

class Media
{
    public string? Title { get; set; }
    public string? Creators { get; set; }
    public string? Genre { get; set; }
    public string? Publisher { get; set; }
    public int Year { get; set; }
    public string? MediaType { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var media1 = new Media
        {
            Title = "My book",
            Creators = "Sandra Andersson",
            Genre = "Horror",
            Publisher = "Knows Nothing AB",
            Year = 2024,
            MediaType = "Book"
        };

        InsertMediaUnsafe(media1);
    }

    static void InsertMediaUnsafe(Media media)
    {
        string connectionString = "server=localhost;database=bibliotek;uid=root;pwd=;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            
            string query = $"INSERT INTO Media (Title, GenreId, Publisher, Year, TypeId) VALUES ('{media.Title}', {GetGenreId(media.Genre, connection)}, '{media.Publisher}', '{media.Year}', {GetMediaTypeId(media.MediaType, connection)})";

            connection.Execute(query);
        }
    }

    static int GetGenreId(string genre, MySqlConnection connection)
    {
        string query = "SELECT Id FROM Genres WHERE Name = @Genre";
        return connection.Query<int>(query, new { Genre = genre }).FirstOrDefault();
    }

    static int GetMediaTypeId(string mediaType, MySqlConnection connection)
    {
        string query = "SELECT Id FROM MediaTypes WHERE Name = @MediaType";
        return connection.Query<int>(query, new { MediaType = mediaType }).FirstOrDefault();
    }
}
*/