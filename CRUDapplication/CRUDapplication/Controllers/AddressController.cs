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

        [HttpGet]
        public string Input()
        {
            return "name done";
        }


        [HttpGet("x")]
        public string Output()
        {
            return "x";

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
                return BadRequest();
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


        [HttpGet("profile")]
        public RedirectResult MyProfile()
        {
            return Redirect("https://www.c-sharpcorner.com/members/farhan-ahmed24");
          
        }


        [HttpGet("profilex")]
        public IActionResult MyProfile2()
        {
          
            return Redirect("~/api/users/x");
        }

        [HttpGet("profilexx")]
     
        public IActionResult GetEmployeeById()
        {
            return LocalRedirect("~/api/users/x");
        }


    }
}
