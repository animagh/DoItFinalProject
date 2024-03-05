using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public interface ILogger
    {
        void SaveLog(string input);
        string GetLog(Operation operation);
        void AddNewLog(Operation model);
        Operation GetLatestOperation(int id);
        List<Operation> GetAllLoG(int id);

    }
}
