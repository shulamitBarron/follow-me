using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace QualiAPI.Models
{
    public class UserProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public ObjectId id { get; set; }
    }
}