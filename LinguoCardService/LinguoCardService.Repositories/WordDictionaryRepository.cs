﻿using System;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using LinguoCardService.DataContracts;
using LinguoCardService.Domain.Abstractions;

namespace LinguoCardService.Repositories
{
    public class WordDictionaryRepository : Repository, IWordDictionaryRepository
    {
        public WordDictionary GetById(int id)
        {
            var responseObject = new WordDictionary();

            string request = $"select e.value as English_value, r.value as Russian_value from Dictionary d join Words e on e.id=d.english_id join Words r on r.id = d.russian_id where d.id =@id";
            var language = CheckRuOrEngWord(id);
            
            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                commande.Parameters.AddWithValue("@id", id);
                var response = commande.ExecuteReader();
                if (!response.HasRows) throw new ArgumentException();
                while (response.Read())
                {
                    responseObject.Id = id;
                    responseObject.EnglishValue = response["English_value"] as string;
                    responseObject.RussianValue = response["Russian_value"] as string;
                }
                return responseObject;
            }
            throw new ArgumentException();
        }

        // TODO Change id (now id of word, but must be id of Dictionary)
        public WordDictionary GetByOriginalWord(string original)
        {
            var responseObject = new WordDictionary();
            var request = $"select Words.id as id, Words.value as value  from Words, (select Words.id as id from Words where Words.value = @original) t1,Dictionary where Dictionary.english_id = t1.id and Dictionary.russian_id = Words.id";
            using (var connection =Connection)
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(request, connection);
                commande.Parameters.AddWithValue("@original", original);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = response["id"] as int? ?? 0;
                        responseObject.EnglishValue = original;
                        responseObject.RussianValue = response["value"] as string; ;
                    }
                }

            }
            return responseObject;
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            var responseObject = new WordDictionary();
            var request = $"select Words.id, Words.value  from Words,  (select Words.id as id from Words where Words.value = @translate) t1,  Dictionary where Dictionary.russian_id = t1.id and Dictionary.english_id = Words.id";
            using (var connection = Connection)
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(request, connection);
                commande.Parameters.AddWithValue("@translate", translate);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = response["id"] as int? ?? 0;
                        responseObject.EnglishValue = response["value"] as string;
                        responseObject.RussianValue = translate;
                    }
                }

            }
            return responseObject;
        }

        public WordDictionary AddWord(string original, string translate)
        {
            var requestEngInsert = $"INSERT INTO [dbo].[Words] ([value],[language]) VALUES (@original, 'eng'); select scope_identity() as id;";
            var requestRusInsert = $"INSERT INTO [dbo].[Words] ([value],[language]) VALUES (@translate, 'ru'); select scope_identity() as id;";
            
            var responseObject = new WordDictionary();

            int engId = 0;
            int rusId = 0;

            using (var connection = Connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(requestEngInsert, connection);
                command.Parameters.AddWithValue("@original", original);
                
                var response = command.ExecuteReader();
                
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        string respId = "";

                        // Каст (int) невозможен, поэтому костыль
                        respId = response["id"].ToString();
                        engId = Int32.Parse(respId);
                    }
                }
                response.Close();

                command = new SqlCommand(requestRusInsert, connection);
                command.Parameters.AddWithValue("@translate", translate);
                
                response = command.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        string respId = "";

                        // Каст (int) невозможен, поэтому костыль
                        respId = response["id"].ToString();
                        rusId = Int32.Parse(respId);
                    }
                }
                response.Close();

                if (engId ==0 || rusId ==0) throw new ArgumentException();
                var requestDictionaryInsert = $"INSERT INTO [dbo].[Dictionary] ([english_id],[russian_id]) VALUES (@engId, @rusId); select scope_identity() as id;";
                command = new SqlCommand(requestDictionaryInsert, connection);
                command.Parameters.AddWithValue("@engId", engId);
                command.Parameters.AddWithValue("@rusId", rusId);

                response = command.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        string respId = "";

                        // Каст (int) невозможен, поэтому костыль
                        respId = response["id"].ToString();
                        responseObject.Id = Int32.Parse(respId);
                    }
                }
                response.Close();

                responseObject.EnglishValue = original;
                responseObject.RussianValue = translate;

            }
            return responseObject;
        }

        public WordDictionary UpdateWord(int id, string newValue)
        {
            var request = $"UPDATE [dbo].[Words] SET[value] = @newValue WHERE Words.id = @id";
            using (var connection = Connection)
            {
                connection.Open();
                var command = new SqlCommand(request, connection);
                command.Parameters.AddWithValue("@newValue", newValue);
                command.Parameters.AddWithValue("@id", id);
                var flag = command.ExecuteNonQuery();
                if(flag==0) throw new ArgumentException();
            }

            var repo  = new WordDictionaryRepository();
            return repo.GetById(id);
        }

        public bool DeleteWord(int id)
        {
            var language = CheckRuOrEngWord(id);
            int engId = 0;
            int ruID = 0;

            if (language.ToString() == "Ru")
            {
                ruID = id;
                var request = $"select Dictionary.english_id as EnglisID from Dictionary where Dictionary.russian_id = @id";
                using (var connection = Connection)
                {
                    connection.Open();
                    var commande = new SqlCommand(request, connection);
                    commande.Parameters.AddWithValue("@id", id);
                    var response = commande.ExecuteReader();
                    if (response.HasRows)
                    {
                        while (response.Read())
                        {
                            engId = (int) response["EnglisID"];
                        }
                    }
                    response.Close();

                    if(engId == 0) throw new ArgumentException();

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id=@ruId; DELETE FROM [dbo].[Words] WHERE Words.id=@engId";
                    commande = new SqlCommand(request, connection);
                    commande.Parameters.AddWithValue("@ruId", ruID);
                    commande.Parameters.AddWithValue("@engId", engId);
                    var flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();
                    
                }
                return true;
            }
            if (language.ToString() == "Eng")
            {
                engId = id;
                var request = $"select Dictionary.russian_id as RussianId from Dictionary where Dictionary.english_id = @id";
                using (var connection = Connection)
                {
                    connection.Open();
                    var commande = new SqlCommand(request, connection);
                    commande.Parameters.AddWithValue("@id", id);
                    var response = commande.ExecuteReader();
                    if (response.HasRows)
                    {
                        while (response.Read())
                        {
                            ruID = (int) response["RussianID"];
                        }
                    }
                    response.Close();

                    if (ruID == 0) throw new ArgumentException();

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id=@ruId; DELETE FROM [dbo].[Words] WHERE Words.id=@engId";
                    commande = new SqlCommand(request, connection);
                    commande.Parameters.AddWithValue("@ruId", ruID);
                    commande.Parameters.AddWithValue("@engId", engId);
                    var flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();
                }
                return true;
            }
            throw new ArgumentException();
        }

        public Language CheckRuOrEngWord(int id)
        {
            var request = $"select Words.language as language from Words where Words.id = @id";
            Language language = Language.Eng;

            using (var conection = Connection)
            {
                conection.Open();
                var commande = new SqlCommand(request, conection);
                commande.Parameters.AddWithValue("@id", id);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                        {
                            var stringResponse = response["language"] as string;
                            var temp = stringResponse?.Split();
                            if (temp != null && temp[0] == "ru") language = Language.Ru;
                            }
                }
                response.Close();
            }
            
            return language;
        }
    }
}