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
            Title = "My book is here",
            Creators = "Sandra Andersson",
            Genre = "Horror",
            Publisher = "Knows Nothing AB",
            Year = 2022,
            MediaType = "Book"
        };

        InsertMediaSafely(media1);
    }

    static void InsertMediaSafely(Media media)
    {
        string connectionString = "server=localhost;database=bibliotek;uid=root;pwd=;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "INSERT INTO Media (Title, GenreId, Publisher, Year, TypeId) VALUES (@Title, @GenreId, @Publisher, @Year, @TypeId)";

            var parameters = new
            {
                Title = media.Title,
                GenreId = GetGenreId(media.Genre, connection),
                Publisher = media.Publisher,
                Year = media.Year,
                TypeId = GetMediaTypeId(media.MediaType, connection)
            };

            connection.Execute(query, parameters);
        }
    }

    static int GetGenreId(string genre, MySqlConnection connection)
    {
        string query = "SELECT Id FROM Genre WHERE Name = @Genre";
        return connection.Query<int>(query, new { Genre = genre }).FirstOrDefault();
    }

    static int GetMediaTypeId(string mediaType, MySqlConnection connection)
    {
        string query = "SELECT Id FROM MediaType WHERE Name = @MediaType";
        return connection.Query<int>(query, new { MediaType = mediaType }).FirstOrDefault();
    }
}
*/