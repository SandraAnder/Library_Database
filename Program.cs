using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

class Media
{
    public string? Titel { get; set; }
    public string? Creators { get; set; }
    public string? Genre { get; set;}
    public string? Publisher { get; set;}
    public string? Year { get; set;}
    public string? MediaType { get; set; }
}

class Program
{
    static List<Media> GetMedias()
    {
        string connectionString = "server=localhost;database=bibliotek;uid=root;pwd=;";

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT M.Title AS Titel, CONCAT(C.FName, ' ', C.LName) AS Creators, G.Name AS Genre, MT.Name AS MediaType " +
                            "FROM Media M " +
                            "INNER JOIN CreatorToMedia CM ON M.Id = CM.MediaId " +
                            "INNER JOIN Creators C ON CM.CreatorId = C.Id " +
                            "INNER JOIN Genre G ON M.GenreId = G.Id " +
                            "INNER JOIN mediatype MT ON M.TypeId = MT.Id " +
                            "WHERE CONCAT (C.FName, ' ', C.LName) = 'Francis Ford Coppola'";

            var media = connection.Query<Media>(query).ToList();

           return media;
        }
    }

    static void Main(string[] args)
    {
        var medias = GetMedias();
        
        // Skriver ut informationen Title och författare, genre och mediatyp.
        foreach (var media in medias)
        {
            Console.WriteLine($"Title: {media.Titel}, Creator: {media.Creators}, Genre: {media.Genre}, MediaType: {media.MediaType}");
        }
    }
}