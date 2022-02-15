using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDapplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {

        private readonly ClassDB classDB;

        public AddressController(ClassDB classDB)
        {
            this.classDB = classDB;
        }

        [HttpGet]
        public string Input()
        {

            classDB.userRecord.Add(new UserRecord(4));
            return "name done";
        }


        [HttpGet("x")]
        public string Output()
        {
            return classDB.userRecord.Count.ToString();


        }

    }
}
