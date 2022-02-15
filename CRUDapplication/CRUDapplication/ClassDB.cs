using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDapplication
{
    public class ClassDB
    {
        public string name="subbu first";
        private readonly ILogger<ClassDB> logger;
        public ClassDB(ILogger<ClassDB> logger)
        {
            this.logger = logger;

        }

        public string GetOutput()
        {
            logger.LogInformation("Class DB was called");
            return "class DB: " + GetHashCode();
        }

    }
}
