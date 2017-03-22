using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CalculatorService.Server.Models
{
    [DataContract]
    public class Operation
    {
        [DataMember (Name = "Operation")]
        public string OperationDes { get; set; }
        [DataMember(Name = "Calculation")]
        public string Calculation { get; set; }
        [DataMember(Name = "Date")]
        public string Date { get; set; }
    }
}