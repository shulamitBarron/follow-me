using QualiAPI.Models;
using System;
using System.Net;
using System.Web.Http;


namespace QualiAPI.Controllers
{
  
    public class GroupController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get([FromBody] string phone)
        {
            try
            {
                object groups = Service.GetGroupsByPhone(phone);
                return Ok(groups);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Unauthorized, ex.Message);
            }
        }


        public void Post([FromBody]Group group)
        {
               listUser.groups.Add(group);
        }
    }
}
