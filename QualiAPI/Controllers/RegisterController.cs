using QualiAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using RestSharp;
using QualiAPI.Properties;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Collections.Specialized;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;



namespace QualiAPI.Controllers
{
    public class RegisterController : ApiController
    {
        public IHttpActionResult Post([FromBody]UserProfile registerUser)
        {

            try
            {

                MongoClient client = new MongoClient("mongodb://chaya1:c0556777462@ds255260.mlab.com:55260/followme");
                MongoServer server = client.GetServer();
                MongoDatabase database = server.GetDatabase("followme");
                MongoCollection userCollection = database.GetCollection("users");
                List<UserProfile> query = userCollection.AsQueryable<UserProfile>().ToList();
                var x = query.FirstOrDefault(sb => sb.phone.Equals(registerUser.phone));
                if (x == null)
                {
                    try
                    {
                        userCollection.Insert(registerUser);
                        return Ok(registerUser.lastName + " " + registerUser.firstName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error :" + ex.Message);

                    }
                }
                else
                {
                    return Content(HttpStatusCode.OK, "user exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to query from collection");
                Console.WriteLine("Exception :" + ex.Message);
                return Content(HttpStatusCode.NotFound, true);

            }
            return Ok("dsfsdfsd");
            // return Content(HttpStatusCode.NotFound,true);
        }

        public void Options() { }
    }
}