using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ATMOperation
{
    public class Logger : ILogger
    {

        private const string _fileLocation = "C:\\Users\\ANI\\source\\repos\\FinalProject\\ATMOperation\\Operations.json";
        private List<Operation> _data ;

        private List<Operation> ParseJson(string input)
        {
            List<Operation> result = JsonSerializer.Deserialize<List<Operation>>(input);

            if (result == null)
            {
                throw new FormatException("Invalid format while deserialization");
            }

            return result;
        }
        private string ToJson(Operation model)
        {
            string jsonObject = JsonSerializer.Serialize(model, new JsonSerializerOptions { WriteIndented = true });
            return jsonObject;
        }

        public void AddNewLog(Operation model)
        {
            var result = ToJson(model);
            SaveLog(result);
        }


        public List<Operation> GetAllLoG(int id)
        {
            string input = File.ReadAllText(_fileLocation);
            if (input.Length < 3) return null;
            _data = ParseJson(input);
            if (_data.Count <= 0)
            {
                return null;
            }

            var result = new List<Operation>();
            foreach (var item in _data)
            {
                if (item.OperationId == id)
                {
                    result.Add(item);
                }

            }
            
            return result;
        }

        public Operation GetLatestOperation(int id)
        {
            _data = GetAllLoG(id);

            if (_data == null) return null;
            
            var latestOperation = _data.OrderByDescending(o => o.OperationTime).FirstOrDefault();

            return latestOperation;
        }

        public string GetLog(Operation operation)
        {
            return operation.OperationName;
        }

        public void SaveLog(string input)
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
