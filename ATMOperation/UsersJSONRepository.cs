using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATMOperation
{
    public class UsersJSONRepository:IRepository
    {

        private const string _fileLocation = "C:\\Users\\ANI\\source\\repos\\FinalProject\\ATMOperation\\Users.json";
        private List<User> _data = new();

        public UsersJSONRepository()
        {
            _data = Parse(File.ReadAllText(_fileLocation));
        }

        private static List<User> Parse(string input)
        {
            
            List<User> result = JsonSerializer.Deserialize<List<User>>(input);
            if (result == null)
            {
                throw new FormatException("Invalid format while deserialization");
            }
            
            return result;
        }
        private static string ToJson(User model)
        {
            string jsonObject = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            return jsonObject;
        }
        public void AddNewUser(User model)
        {
            var result = ToJson(model);
            Save(result);
        }
        public List<User> GetAllUser()
        {
            
            if (_data.Count <= 0)
            {
                throw new Exception("Data storage is empty");
            }

            return _data;
        }
        public User GetSingleUser(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }

            var result = _data.FirstOrDefault(x => x.Id == id);


            return result;
        }


        public void Save(string input)
        {
            if (!input.StartsWith("{") || !input.EndsWith("}"))
            {
                throw new FormatException("Input is not valid JSON format");
            }

            if (!File.Exists(_fileLocation))
            {
                File.WriteAllText(_fileLocation, "[]");
            }

            string existingJson = File.ReadAllText(_fileLocation);

            if (!string.IsNullOrWhiteSpace(existingJson))
            {
                existingJson = existingJson.Trim(']');
            }

            input = $",{input}";

            File.WriteAllText(_fileLocation, $"{existingJson}{input}]");

        }
    }

}

