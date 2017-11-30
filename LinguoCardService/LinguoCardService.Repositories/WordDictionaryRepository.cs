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
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        public WordDictionary GetById(int id)
        {
            var responseObject = new WordDictionary();
            
            string request = null;
            var language = CheckRuOrEngWord(id);
            
            if (language.ToString()=="ru")
            {
                request =
                    $"select t1.value as Russian, Words.value as English from Words,(select Dictionary.id as id, Words.value as value, Dictionary.english_id as englishID from Words, Dictionary where Words.id = '{id}' and Dictionary.russian_id = Words.id) t1 where Words.id=t1.englishID;";
            }
            if(language.ToString()=="eng")
            {
                request = $"select t1.value as English, Words.value as Russian from Words,(select Dictionary.id as id, Words.value as value, Dictionary.russian_id as russianID from Words, Dictionary where Words.id = '{id}' and Dictionary.english_id = Words.id) t1 where Words.id=t1.russianID;";
            }
            

            
            using (var connection = Connection)
            {
                connection.Open();
                var commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (!response.HasRows) return responseObject;
                while (response.Read())
                {
                    responseObject.Id = id;
                    responseObject.Original = response["English"] as string;
                    responseObject.Translate = response["Russian"] as string;
                }
            }
            return responseObject;
        }

        public WordDictionary GetByOriginalWord(string original)
        {
            var responseObject = new WordDictionary();
            var request = $"select Words.id as id, Words.value as value  from Words, (select Words.id as id from Words where Words.value = '{original}') t1,Dictionary where Dictionary.english_id = t1.id and Dictionary.russian_id = Words.id";
            using (var connection =Connection)
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = response["id"] as int? ?? 0;
                        responseObject.Original = original;
                        responseObject.Translate = response["value"] as string; ;
                    }
                }

            }
            return responseObject;
        }

        public WordDictionary GetByTranslateWord(string translate)
        {
            var responseObject = new WordDictionary();
            var request = $"select Words.id, Words.value  from Words,  (select Words.id as id from Words where Words.value = '{translate}') t1,  Dictionary where Dictionary.russian_id = t1.id and Dictionary.english_id = Words.id";
            using (var connection = Connection)
            {
                connection.Open();
                SqlCommand commande = new SqlCommand(request, connection);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = response["id"] as int? ?? 0;
                        responseObject.Original = response["value"] as string;
                        responseObject.Translate = translate;
                    }
                }

            }
            return responseObject;
        }

        public WordDictionary AddWord(string original, string translate)
        {
            var requestEngInsert = $"INSERT INTO [dbo].[Words] ([value],[language]) VALUES ('{original}', 'eng')";
            var requestEngGet = $"select Words.id  as id from Words where Words.value='{original}';";
            var requestRusInsert = $"INSERT INTO [dbo].[Words] ([value],[language]) VALUES ('{translate}', 'ru')";
            var requestRusGet = $"select Words.id  as id from Words where Words.value='{translate}';";
            var responseObject = new WordDictionary();

            int engId = 0;
            int rusId = 0;

            using (var connection = Connection)
            {
                connection.Open();
                SqlCommand command = new SqlCommand(requestEngInsert, connection);
                var flag = command.ExecuteNonQuery();
                if(flag == 0) throw new ArgumentException();
               

                command = new SqlCommand(requestEngGet, connection);
                var response = command.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        engId = (int) response["id"];
                    }
                }
                response.Close();

                command = new SqlCommand(requestRusInsert, connection);
                flag = command.ExecuteNonQuery();
                if(flag == 0) throw  new ArgumentException();

                command = new SqlCommand(requestRusGet, connection);
                response = command.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        rusId = (int)response["id"];
                    }
                }
                response.Close();

                if (engId ==0 || rusId ==0) throw new ArgumentException();
                var requestDictionaryInsert = $"INSERT INTO [dbo].[Dictionary] ([english_id],[russian_id]) VALUES ({engId}, {rusId})";
                command = new SqlCommand(requestDictionaryInsert, connection);
                flag = command.ExecuteNonQuery();
                if (flag == 0) throw new ArgumentException();

                var requestDictionaryId = $"select Dictionary.id from Dictionary where Dictionary.english_id='{engId}'";
                command = new SqlCommand(requestDictionaryId, connection);
                response = command.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                    {
                        responseObject.Id = (int)response["id"];
                    }
                }
                response.Close();

                responseObject.Original = original;
                responseObject.Translate = translate;

            }
            return responseObject;
        }

        public WordDictionary UpdateWord(int id, string newValue)
        {
            var request = $"UPDATE [dbo].[Words] SET[value] = '{newValue}' WHERE Words.id = {id}";
            using (var connection = Connection)
            {
                connection.Open();
                var command = new SqlCommand(request, connection);
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

            if (language.ToString() == "ru")
            {
                ruID = id;
                var request = $"select Dictionary.english_id as EnglisID from Dictionary where Dictionary.russian_id = '{id}'";
                using (var connection = Connection)
                {
                    connection.Open();
                    var commande = new SqlCommand(request, connection);
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

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id='{ruID}'";
                    commande = new SqlCommand(request, connection);
                    var flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id='{engId}'";
                    commande = new SqlCommand(request, connection);
                    flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();
                }
                return true;
            }
            if (language.ToString() == "eng")
            {
                engId = id;
                var request =
                    $"select Dictionary.russian_id as RussianId from Dictionary where Dictionary.english_id = '{id}'";
                using (var connection = Connection)
                {
                    connection.Open();
                    var commande = new SqlCommand(request, connection);
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

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id='{ruID}'";
                    commande = new SqlCommand(request, connection);
                    var flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();

                    request = $"DELETE FROM [dbo].[Words] WHERE Words.id='{engId}'";
                    commande = new SqlCommand(request, connection);
                    flag = commande.ExecuteNonQuery();
                    if (flag == 0) throw new ArgumentException();
                }
                return true;
            }
            return false;
        }

        public Language CheckRuOrEngWord(int id)
        {
            var request = $"select Words.language as language from Words where Words.id = {id}";
            Language language = Language.eng;

            using (var conection = Connection)
            {
                conection.Open();
                var commande = new SqlCommand(request, conection);
                var response = commande.ExecuteReader();
                if (response.HasRows)
                {
                    while (response.Read())
                        {
                            var stringResponse = response["language"] as string;
                            var temp = stringResponse?.Split();
                            if (temp != null && temp[0] == "ru") language = Language.ru;
                            }
                }
                response.Close();
            }
            
            return language;
        }
    }
}