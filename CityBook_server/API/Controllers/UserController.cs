using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Excel = Microsoft.Office.Interop.Excel;
using BL;
using DTO;

namespace API.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET: api/User
        public void Get()
        {

        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("api/User/AddUser")]
        public string AddUser([FromBody]Us user)
        {
            string x = HttpContext.Current.Server.MapPath("ExcelFile/");
            string message = UserBL.AddUser(user.user, user.children);
            UserBL.CreateExcel(user.user, x);
            return message;
        }



        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
