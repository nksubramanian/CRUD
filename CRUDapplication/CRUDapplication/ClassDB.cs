using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapplication
{
    public class ClassDB
    {
        public readonly List<UserRecord> userRecords;
  
        public ClassDB(List<UserRecord> userRecords)
        {
            this.userRecords = userRecords;

        }

        public void AddRecord(int id, string address)
        {
            try 
            {
                bool isExist = false;
                foreach(var record in userRecords)
                {
                    if(record.userId==id)
                    {
                        isExist = true;
                        throw new InvalidOperationException("Record already exists");
              
                    }
                }
                userRecords.Add(new UserRecord(id, address));
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Operation Failed");
            } 
        }

        public string GetRecord(int id)
        {
            try
            {
                bool isExist = false;
                foreach (var record in userRecords)
                {
                    if (record.userId == id)
                    {

                        return record.address;

                    }
                }

                throw new InvalidOperationException("Does not exists");

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Operation Failed");
            }
        }








    }
}
