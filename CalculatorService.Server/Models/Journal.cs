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
           
            List<Operation> listOperations = new  List<Operation>();

            // Check if the key [id] exists in Cache, if not exist store a new key, else update
            // the list of operations in the key [id]
            if (Cache.Exists(Id.ToString()))
            {
                listOperations =  (List<Operation>)Cache.Get(Id.ToString());
                listOperations.Add(Operation);
                Cache.Update(Id.ToString(), listOperations);
            }
            else
            {
                listOperations.Add(Operation);
                Cache.Store(Id.ToString(), listOperations);
            }
        }

        public static List<Operation> get(int Id)
        {

            List<Operation>  listOperations = new List<Operation>();
          
            //returns the operation lists in the key [id]
            if (Cache.Exists(Id.ToString()))
            {
                listOperations = (List<Operation>)Cache.Get(Id.ToString());
            }

            return listOperations;      
        }
    }

  
}