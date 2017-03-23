using MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CalculatorService.Server.Models
{
    public static class Journal
    {

        public static void store(string id, Operation operation)
        {

            List<Operation> operations = new List<Operation>();            

            // Check if the key [id] exists in Cache, if not exist store a new key, else update
            // the list of operations in the key [id]
            if (Cache.Exists(id))
            {
                operations = (List<Operation>)Cache.Get(id);
                operations.Add(operation);
                Cache.Update(id, operations);
            }
            else
            {
                operations.Add(operation);
                Cache.Store(id, operations);
            }
        }

        public static List<Operation> get(string id)
        {                      
            //returns the operation lists in the key [id]
            if (Cache.Exists(id))
            {
                return (List<Operation>)Cache.Get(id);
            }
            else
            {
                return null;
            }
        }
    }

  
}