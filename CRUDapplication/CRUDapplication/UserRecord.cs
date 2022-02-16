using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapplication
{
    public class UserRecord
    {
        public int userId;
        public string address;

        public UserRecord(int x, string address)
        {
            this.userId = x;
            this.address = address;
        }

    }

}
