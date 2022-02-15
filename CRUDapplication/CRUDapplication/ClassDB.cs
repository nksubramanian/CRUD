using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapplication
{
    public class ClassDB
    {
        public readonly List<UserRecord> userRecord;
  
        public ClassDB(List<UserRecord> userRecord)
        {
            this.userRecord = userRecord;

        }

        public string GetOutput()
        {
            return userRecord[0].userId.ToString();
        }

    }
}
