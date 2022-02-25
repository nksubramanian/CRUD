using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDapplication.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class AddressController : ControllerBase
    {

        private readonly ClassDB classDB;

        public AddressController(ClassDB classDB)
        {
            this.classDB = classDB;
            
        }

        [HttpPost]
        [Route("{userid}/address")]
        public async Task<IActionResult> JsonStringBody([FromRoute] int userid)
        {
            try
            {
                string address;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    address = await reader.ReadToEndAsync();
                }

                classDB.AddRecord(userid, address);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{userid}/address")]
        public async Task<IActionResult> GetAddress([FromRoute] int userid)
        {
    
            try
            {
                string address = classDB.GetRecord(userid);
                return Ok(address);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("{userid}/address")]
        public async Task<IActionResult> ModifyAddress([FromRoute] int userid)
        {
            try
            {
                string address;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    address = await reader.ReadToEndAsync();
                }

                classDB.ModifyRecord(userid, address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("exception")]
        public async Task<IActionResult> GetExceptions()
        {

            try
            {

                Dictionary<string, string> requestHeaders =
               new Dictionary<string, string>();
                foreach (var header in Request.Headers)
                {
                    requestHeaders.Add(header.Key, header.Value);
                }
               

                return Ok(classDB.GetException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
