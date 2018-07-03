using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QualiAPI.Models
{
    public class Group
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public List<UserProfile> users { get; set; }
    }
}
