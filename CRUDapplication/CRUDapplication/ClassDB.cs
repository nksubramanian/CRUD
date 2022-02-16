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
        public readonly List<string> exceptions;

        public ClassDB(List<UserRecord> userRecords, List<string> exceptions)
        {
            this.userRecords = userRecords;
            this.exceptions = exceptions;

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
                exceptions.Add(ex.Message);
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
                exceptions.Add(ex.Message);
                throw new InvalidOperationException("Operation Failed");
            }
        }


        public void ModifyRecord(int id, string address)
        {
            try
            {
                foreach (var record in userRecords)
                {
                    if (record.userId == id)
                    {

                        record.address = address;
                        return;

                    }
                }
                throw new InvalidOperationException("Record does not exist");
            }
            catch (Exception ex)
            {
                exceptions.Add(ex.Message);
                throw new InvalidOperationException("Operation Failed");
            }
        }

        public List<string> GetException()
        {
            try
            {
                return exceptions;
               
            }
            catch (Exception ex)
            {
                exceptions.Add(ex.Message);
                throw new InvalidOperationException("Operation Failed");
            }
        }




    }
}
