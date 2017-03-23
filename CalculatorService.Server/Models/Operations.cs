using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CalculatorService.Server.Models
{
    [DataContract]
    public class Operations
    {
        [DataMember(Name = "Operations")]
        public List<Operation> ListOperations;

    }
}