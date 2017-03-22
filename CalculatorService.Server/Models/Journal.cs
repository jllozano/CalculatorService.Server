using MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CalculatorService.Server.Models
{
    public static class Journal
    {

        public static void store(int Id, Operation Operation)
        {
            List<Operation> operationList = new List<Operation>();

            if (Cache.Exists(Id.ToString()))
            {
                operationList =  (List<Operation>)Cache.Get(Id.ToString());
                operationList.Add(Operation);
                Cache.Update(Id.ToString(), operationList);
            }
            else
            {
                operationList.Add(Operation);
                Cache.Store(Id.ToString(), operationList);
            }
        }

        public static List<Operation> get(int Id)
        {
            List<Operation> operationList = new List<Operation>();

            if (Cache.Exists(Id.ToString()))
            {
                operationList = (List<Operation>)Cache.Get(Id.ToString());
            }

            return operationList;      
        }
    }

  
}