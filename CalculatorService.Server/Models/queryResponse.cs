using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorService.Server.Models
{
    public class QueryResponse
    {
        public List<Operation> Operations { get; set; }
    }
}