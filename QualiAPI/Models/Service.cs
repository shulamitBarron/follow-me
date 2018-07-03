﻿using Newtonsoft.Json;
using Okta.Core.Clients;
using Okta.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace QualiAPI.Models
{
    public class Service
    {
        private static WebRequest req;

        public static void Error(string errorMessage, [CallerFilePath]string memberName = "")
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath(@"~/bin/logs/error.dat"), DateTime.Now + "\t" + memberName + "\t" + errorMessage + Environment.NewLine);
        }


        public static object GetGroupsByPhone(string phone)
        {
            req = WebRequest.Create("/api/v1/users");
            req.Method = "GET";
            req.ContentType = "application/json";
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

            object response;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(resp.GetResponseStream(), encoding))
            {
                response = JsonConvert.DeserializeObject(reader.ReadToEnd());
                return response;

            }
        }

    }
}