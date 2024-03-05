using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMOperation
{
    public class Operation
    {
        public int OperationId { get; set; }

        public DateTime OperationTime { get; set; }

        public double changeAmmount { get; set; }
        public double CurrentBalance { get; set; }
        public string OperationName { get; set; }

    }
}
